using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace EmployeePayrollJsonDB
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;
        [TestInitialize]
        public void Setup()
        {

            client = new RestClient("http://localhost:3000");
        }

        public List<Employee> ReadData()
        {
            RestRequest request = new RestRequest("/employee", Method.GET);
            IRestResponse response = client.Execute(request);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            return employees;
        }



        public HttpStatusCode UpdateData(string name, string property, int value)
        {
            List<Employee> employees = ReadData();

            int i = 0;
            foreach (var employee in employees)
            {
                i++;
                if (employee.Equals(name))
                    break;
            }

            try
            {
                RestRequest request = new RestRequest("/employee/" + i, Method.PATCH);
                JObject JsonContact = new JObject();
                JsonContact.Add(property, value);

                request.AddParameter("application/json", JsonContact, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                return response.StatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return HttpStatusCode.NotFound;
            }
        }

        public HttpStatusCode DeleteData(string name, string property, int value)
        {
            List<Employee> employees = ReadData();

            int i = 0;
            foreach (var employee in employees)
            {
                i++;
                if (employee.Equals(name))
                    break;
            }

            try
            {
                RestRequest request = new RestRequest("/employee/" + i, Method.DELETE);
                JObject JsonContact = new JObject();
                IRestResponse response = client.Execute(request);

                return response.StatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return HttpStatusCode.NotFound;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<Employee> employees = ReadData();
            Assert.AreEqual(employees.Count, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            HttpStatusCode responseCode = HttpStatusCode.BadRequest;
            try
            {
                string name = "Prathamesh";
                int Salary = 10000;
                string startDate = "9/11/2020";
                decimal PhoneNumber = 123456780;
                string dept = "IT";
                string add = "Home";
                char gender = 'M';
                string email = "abc@gmail.com";

                RestRequest request = new RestRequest("/employee", Method.POST);
                JObject JsonContact = new JObject();
                JsonContact.Add("Name", name);
                JsonContact.Add("Salary", Salary);
                JsonContact.Add("StartDate", startDate);
                JsonContact.Add("PhoneNumber", PhoneNumber);
                JsonContact.Add("Department", dept);
                JsonContact.Add("Address", add);
                JsonContact.Add("Gender", gender);
                JsonContact.Add("Email", email);

                request.AddParameter("application/json", JsonContact, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                responseCode = response.StatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Assert.AreEqual(responseCode, HttpStatusCode.Created);
        }

        [TestMethod]
        public void TestMethod3()
        {
            HttpStatusCode responseCode = HttpStatusCode.BadRequest;
            try
            {
                List<Employee> employees = new List<Employee>();

                employees.Add(new Employee("asdf", 1000, "11/10/2020", 1234567890, "Mech", "Mumbai", 'F'));
                employees.Add(new Employee("sdfds", 2000, "09/01/2020", 1561894491, "Mech", "Mumbai", 'M'));

                foreach (var employee in employees)
                {
                    RestRequest request = new RestRequest("/employee", Method.POST);
                    JObject JsonContact = new JObject();
                    JsonContact.Add("Name", employee.Name);
                    JsonContact.Add("Salary", employee.Salary);
                    JsonContact.Add("StartDate", employee.StartDate);
                    JsonContact.Add("PhoneNumber", employee.PhoneNumber);
                    JsonContact.Add("Department", employee.Department);
                    JsonContact.Add("Address", employee.Address);
                    JsonContact.Add("Gender", employee.Gender);

                    request.AddParameter("application/json", JsonContact, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);

                    Assert.AreEqual(responseCode, HttpStatusCode.Created);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        [TestMethod]
        public void TestMethod4()
        {
            string name = "Prathamesh";
            string property = "Salary";
            int sal = 40000;

            Assert.AreEqual(HttpStatusCode.OK, UpdateData(name, property, sal));
        }

        [TestMethod]
        public void TestMethod5()
        {
            string name = "Prathamesh";
            string property = "Salary";
            int sal = 40000;

            Assert.AreEqual(HttpStatusCode.OK, DeleteData(name, property, sal));
        }
    }
}

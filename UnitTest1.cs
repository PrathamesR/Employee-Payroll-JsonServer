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

        [TestMethod]
        public void TestMethod1()
        {
            RestRequest request = new RestRequest("/employee", Method.GET);
            IRestResponse response = client.Execute(request);
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            Assert.AreEqual(employees.Count, 1);
        }        
    }
}

using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollJsonDB
{
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string StartDate { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }

        public Employee(string name, int salary, string startDate, decimal phoneNumber, string department, string address, char gender)
        {
            Name = name;
            Salary = salary;
            StartDate = startDate;
            PhoneNumber = phoneNumber;
            Department = department;
            Address = address;
            Gender = gender;
        }

    }
}

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
    }
}

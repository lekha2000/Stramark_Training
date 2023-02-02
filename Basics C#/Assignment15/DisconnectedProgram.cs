using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using Utility;

namespace SampleDataAccessApp
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int salary { get; set; }
        public int DeptId { get; set; }
        public int EmpSalary { get; internal set; }
    }

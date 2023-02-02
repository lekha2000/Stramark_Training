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
interface IDatacomponent
    {
        void AddEmployees(Employee Emp);
        void UpdateEmployee(Employee Emp);
        void DeleteEmployee(int id);
    }
    
    class DisconnectedProgram : IDatacomponent
    {
        static string strcon = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        const string query = "Select * from tblEmployee"; //Select * from Dept;
        //const string deptquery = "Select * from Dept";
        static DataSet dataSet = new DataSet("AllRecords");
        static SqlDataAdapter ada = null; 


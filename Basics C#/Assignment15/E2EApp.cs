using SampleDataAccessApp.Practical.Dalayer;
using SampleDataAccessApp.Practical.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace SampleDataAccessApp.Practical
{
    namespace Entities
    {
        class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpAddress { get; set; }
            public int EmpSalary { get; set; }
            public int DeptId { get; set; }
        }
        class Dept
        {
            public int DeptId { get; set; }
            public string DeptName { get; set; }
        }

    }
    namespace Dalayer
    {
        interface IDataAccessComponent
        {
            void AddNewEmployee(Employee emp);
            void UpdateEmployee(Employee emp);
            void DeleteEmployee(int id);
            List<Employee> GetAllEmployees();
            List<Dept> GetAllDepts();
        }

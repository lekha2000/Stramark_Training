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
        class DataComponent : IDataAccessComponent
        {
            private string strCon = string.Empty;

            #region SqlStatements
            const string STRINSERT = "InsertEmployee";
            const string STRUPDATE = "Update tblEmployee Set EmpName = @EmpName, EmpAddress = @EmpAddress, EmpSalary = @EmpSalary WHERE EmpId = @EmpId";
            const string STRALL = "SELECT * FROM TBLEMPLOYEE";
            const string STRALLDEPTS = "SELECT * FROM TBLDEPT";
            const string STRDELETE = "DELETE FROM TBLEMPLOYEE WHERE EMPID = @id";
            #endregion


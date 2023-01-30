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

            #region HELPERS
            private void NonQueryExecute(string query, SqlParameter[] parameters, CommandType type)
            {
                SqlConnection con = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = type;
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            private DataTable GetRecords(string query, SqlParameter[] parameters, CommandType type = CommandType.Text)
            {
                SqlConnection con = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = type;
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                try
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    DataTable table = new DataTable("Records");
                    table.Load(reader);
                    return table;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            #endregion
            public DataComponent(string connectionString)
            {
                strCon = connectionString;
            }
            #region IDataAccessComponentImpl
            public void AddNewEmployee(Employee emp)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@EmpName", emp.EmpName));
                parameters.Add(new SqlParameter("@EmpAddress", emp.EmpAddress));
                parameters.Add(new SqlParameter("@EmpSalary", emp.EmpSalary));
                parameters.Add(new SqlParameter("@Department", emp.DeptId));
                parameters.Add(new SqlParameter("@EmpId", emp.EmpId));
                try
                {
                    NonQueryExecute(STRINSERT, parameters.ToArray(), CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }




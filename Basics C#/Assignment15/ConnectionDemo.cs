using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Utility;

namespace SampleDataAccessApp
{
    static class Database
    {
        const string STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3316;Integrated Security=True";

        const string STRQUERY = "SELECT * FROM tblEmployee  ";
        const string STRQRY = "SELECT * FROM Dept ";
        const string STRQUER = "SELECT * FROM tblEmployee WHERE DeptName = @dname ";
        public static DataTable GetAllRecords()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRQUERY, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable("EmpRecords");
                table.Load(reader);
                return table;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                con.Close();
            }
            return null;
        }
        public static DataTable GetRecords()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRQRY, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable("EmpRecords");
                table.Load(reader);
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return null;
        }
    }
    class ConnectionDemo
    {
        const string STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3316;Integrated Security=True";

        const string STRQUERY = "SELECT * FROM Dept WHERE DeptName = @dname ";

        const string STRINSERTPROG = "InsertEmployee";

const string STRINSERT = "insert into tblEmployee values(@name,@address,@salary,@did)";
        private static void ReadData()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = STRCONNECTION;
            SqlCommand sqlCommand = sqlCon.CreateCommand();
            sqlCommand.CommandText = STRQUERY;
        try
            {
                sqlCon.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmpName"]} \t {reader["EmpAddress"]}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlCon.State == System.Data.ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }
        private static void DisplayByName(string name)
        {
            const string STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3316;Integrated Security=True";

            string STRQUERY = $"SELECT * FROM tblEmployee WHERE EmpName LIKE '%{name}%' ";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRQUERY, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                var table = Database.GetAllRecords();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmpName"]} \t {reader["EmpAddress"]}");
                }
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void DisplayAsTable()
        {
            try
            {
                var table = Database.GetAllRecords();
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"EmpName: {row[1]}\nEmpAddress: {row[2]}\nEmpSalary : {row[3]}\nDepartment : {row[4]}");
                }
            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        static void Main(string[] args)
        {
            //ReadData();
            //DisplayAsTable();
            //DisplayByName("Lekha");
            //DisplayUsingParameter("Lekha");

            /*string name = Utilities.Prompt("Enter The Name: ");
            string address = Utilities.Prompt("Enter The Address : ");
            int salary = Utilities.GetNumber("Enter The Salary : ");
            int deptid = Utilities.GetNumber("Enter the Department ID : ");*/

            //AddNewRecord(name, address, salary, deptid);
            //DisplayAsTable();

            DisplayDept();
            int did = Utilities.GetNumber("Enter The Department ID: ");
            string name = Utilities.Prompt("Enter The Name: ");
            string address = Utilities.Prompt("Enter The Address : ");
            int salary = Utilities.GetNumber("Enter The Salary : ");
            //int deptid = Utilities.GetNumber("Enter the Department ID : ");

            AddNewRecord(name, address, salary, did);
            //AddNewRecordUsingStoredProc(name, address, salary, did);
            DisplayAsTable();
           
        }
        private static void AddNewRecordUsingStoredProc(string name, string address, int salary, int did)
        {
            int empId = 0;
            SqlCommand cmd = new SqlCommand(STRINSERTPROG, new SqlConnection(STRCONNECTION));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpName", name);
            cmd.Parameters.AddWithValue("@EmpAddress", address);
            cmd.Parameters.AddWithValue("@EmpSalary", salary);
            cmd.Parameters.AddWithValue("@Department", did);
            cmd.Parameters.AddWithValue("@EmpId", empId);
            cmd.Parameters[4].Direction = ParameterDirection.Output;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                empId = Convert.ToInt32(cmd.Parameters[4].Value);
                Console.WriteLine("The EmpId of the newly added Employee is :  "+ empId);
            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            }




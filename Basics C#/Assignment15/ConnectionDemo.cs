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



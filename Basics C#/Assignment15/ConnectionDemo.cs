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

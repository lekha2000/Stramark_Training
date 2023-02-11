using System;
using System.Collections.Generic;
using System.Data;
using SampleDataAccessApp.Entities;
using System.Data.SqlClient;

namespace SampleDataAccessApp
{
    namespace Entities
    {
        class Disease
        {
            public int DiseaseId { get; set; }
            public string DiseaseName { get; set; }
            public string DiseaseSeverity { get; set; }
            public string DiseaseCause { get; set; }
            public int SymptomId { get; set; }
        }
        class Symptom
        {
            public int SymptomId { get; set; }
            public string SymptomName { get; set; }
        }

    }
    namespace Dalayer
    {
        interface IDataAccessComponent
        {
            void AddNewDisease(Disease emp);
            void UpdateDisease(Disease emp);
            void DeleteDisease(int id);
            List<Disease> GetAllDisease();
            List<Symptom> GetAllSymptoms();
        }
        class DataComponent : IDataAccessComponent
        {
            private string strCon = string.Empty;

            #region SqlStatements
            const string STRINSERT = "Disease";
            //const string STRUPDATE = "Update tblEmployee Set EmpName = @EmpName, EmpAddress = @EmpAddress, EmpSalary = @EmpSalary WHERE EmpId = @EmpId";

            const string STRUPDATE = "Update tblDisease Set DiseaseName = @disName, DiseaseSeverity = @disSeverity, DiseaseCause = @disCause WHERE DiseaseId = @disId";
            const string STRALL = "SELECT * FROM TBLDISEASE ";
            const string STRALLDEPTS = "SELECT * FROM TBLSYMPTOM";
            const string STRDELETE = "DELETE FROM TBLDISEASE WHERE DiseaseId = @id";
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
                    DataTable table = new DataTable("DiseaseRecords");
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
            #region IDataAccessComponentImpl
            public DataComponent(string connectionString)
            {
                strCon = connectionString;
            }
            public void AddNewDisease(Disease dis)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@disName", dis.DiseaseName));
                parameters.Add(new SqlParameter("@disSeverity", dis.DiseaseSeverity));
                parameters.Add(new SqlParameter("@disCause", dis.DiseaseCause));
                parameters.Add(new SqlParameter("@symptId", dis.SymptomId ));
                parameters.Add(new SqlParameter("@disId", dis.DiseaseId));
                try
                {
                    NonQueryExecute(STRINSERT, parameters.ToArray(), CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
             }
            public void UpdateDisease(Disease dis)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@disName", dis.DiseaseName));
                parameters.Add(new SqlParameter("@disSeverity", dis.DiseaseSeverity));
                parameters.Add(new SqlParameter("@disCause", dis.DiseaseCause));
                parameters.Add(new SqlParameter("@disId", dis.DiseaseId));
                try
                {
                    NonQueryExecute(STRUPDATE, parameters.ToArray(), CommandType.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void DeleteDisease(int id)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@id", id));
                try
                {
                    NonQueryExecute(STRDELETE, parameters.ToArray(), CommandType.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public List<Disease> GetAllDisease()
            {
                var table = GetRecords(STRALL, null);
                List<Disease> dislist = new List<Disease>();
                foreach (DataRow row in table.Rows)
                {
                    //var deptId = (SqlInt32)row[4];
                    //row.IsNull(4) ? 0 : (int)row[4]
                    Disease dis = new Disease
                    {
                        DiseaseId = (int)row[0],
                        DiseaseName = row[1].ToString(),
                        DiseaseSeverity = row[2].ToString(),
                        DiseaseCause = row[3].ToString(),
                        SymptomId = (int)row[4]
                    };
                    dislist.Add(dis);
                }
                return dislist;
            }
            public List<Symptom> GetAllSymptoms()
            {
                var table = GetRecords(STRALLDEPTS, null);
                List<Symptom> syms = new List<Symptom>();

                foreach (DataRow row in table.Rows)
                {
                    Symptom sym = new Symptom
                    {
                        SymptomId = Convert.ToInt32(row[0]),
                        SymptomName = row[1].ToString()
                    };
                    syms.Add(sym);
                }
                return syms;
            }

            #endregion
        }
    }
    namespace UILayer
    {
        using SampleDataAccessApp.Dalayer;
        using System.Configuration;
        using Utility;

        class E2EAppDisease
        {
            static IDataAccessComponent component = null;
            static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            static void Main(string[] args)
            {
                component = new DataComponent(connectionString);

                component.AddNewDisease(new Disease
                {
                    DiseaseName = Utilities.Prompt("Enter the Disease Name"),
                    DiseaseSeverity = Utilities.Prompt("Enter the Disease Severity"),
                    DiseaseCause = Utilities.Prompt("Enter the Disease Cause"),
                    SymptomId = Utilities.GetNumber("Enter the SymptomId")
                });

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


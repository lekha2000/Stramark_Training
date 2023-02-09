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


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

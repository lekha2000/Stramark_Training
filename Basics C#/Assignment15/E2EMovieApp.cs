using SampleDataAccessApp.DataLayerMovie;
using SampleDataAccessApp.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataAccessApp
{
    namespace Entity
    {
        class Movie
        {
            public int MovieId { get; set; }
            public string MovieTitle { get; set; }
            public string MovieDuration { get; set; }
            public int MovieRating { get; set; }
            public int DirectorId { get; set; }
        }


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
        class Actor
        {
            public int ActorId { get; set; }
            public string ActorName { get; set; }
            public int ActorAge { get; set; }
            public string ActorDesc { get; set; }
        }
        class Director
        {
            public int DirectorId { get; set; }
            public string DirectorName { get; set; }
            public int DirectorAge { get; set; }
        }
        class Entry
        {
            public int EntryId { get; set; }
            public int ActorId { get; set; }
            public int MovieId { get; set; }
        }
    }
    namespace DataLayerMovie{
        
        interface IMovieDatabase
        {
            void AddMovie(Movie movie);
            void AddActor(Actor actor);
            void AddDirector(Director dir);

            void UpateMovie(Movie movie);
            void UpdateActor(Actor actor);
            void UpdateDirector(Director director);

            void DeleteMovie(int id);
            void AddEntry(Entry entry);

            List<Movie> DisplayAllMovies();
            List<Actor> DisplayAllActor();
            List<Director> DisplayAllDirectors();
            List<Entry> DisplayAllEntry();
        } 
        class MovieData : IMovieDatabase
        {
            private string strCon = string.Empty;

            #region MySql
            const string qMovie = "InsertMovie";
            const string qActor = "InsertActor";
            const string qDirector = "InDirector";
            const string qEntry = "InsertEntry";
            const string updateM = "Update tblMovie set MovieTitle = @movieTitle, MovieDuration  = @movieduration, MovieRating = @movieRating where MovieId = @movieId";
            const string updateA = " Update tblActor set ActorName = @actorName,ActorAge = @actorAge,ActorDesc = @actorDesc Where ActorId = @actorId";
            const string updateD = "Update tblDirector set DirectorName = @directorName, DirectorAge = @directorAge";

            const string delMovie = "Delete from tblMovie where MovieId = @movieId";

            const string dqMovie = "Select * From tblMovie";
            const string dqActor = "Select * From tblActor";
            const string dqDirector = "select * from tblDirector";
            #endregion

            #region Connection
            private  void NonQuery(string query, SqlParameter[] par, CommandType type)
            {
                SqlConnection con = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.CommandType = type;
                if(par != null)
                {
                    foreach (SqlParameter parameter in par)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            private DataTable GetQueryy(string query,SqlParameter[] par, CommandType type = CommandType.Text)
            {
                SqlConnection con = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = type;
                if (par != null)
                {
                    foreach (SqlParameter parameter in par)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    
                }

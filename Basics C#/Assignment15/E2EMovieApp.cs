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
                try
                {
                    cmd.Connection.Open();
                    var reader = cmd.ExecuteReader();
                    DataTable table = new DataTable("Records");
                    table.Load(reader);
                    return table;
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return null;
            }
            #endregion

            //constructor
            public MovieData(string strConnection)
            {
                strCon = strConnection;
            }

            #region Components 
            public void AddActor(Actor actor)
            {
                List<SqlParameter> act = new List<SqlParameter>();
                act.Add(new SqlParameter("@actorName", actor.ActorName));
                act.Add(new SqlParameter("@actorAge", actor.ActorAge));
                act.Add(new SqlParameter("@actorDesc", actor.ActorDesc));
                act.Add(new SqlParameter("@actorId", actor.ActorId));
                try
                {
                    NonQuery(qActor, act.ToArray(), CommandType.StoredProcedure);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void AddDirector(Director dir)
            {
                List<SqlParameter> dire = new List<SqlParameter>();
                dire.Add(new SqlParameter("@directorName", dir.DirectorName));
                dire.Add(new SqlParameter("@directorAge", dir.DirectorAge));
                dire.Add(new SqlParameter("@directorId", dir.DirectorId));
            try
                {
                    NonQuery(qDirector, dire.ToArray(), CommandType.StoredProcedure);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void AddEntry(Entry entry)
            {
                List<SqlParameter> ent = new List<SqlParameter>();
                ent.Add(new SqlParameter("@movieId", entry.MovieId));
                ent.Add(new SqlParameter("@actorId", entry.ActorId));
                ent.Add(new SqlParameter("@entryId", entry.EntryId));
            try
                {
                    NonQuery(qEntry, ent.ToArray(), CommandType.StoredProcedure);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void AddMovie(Movie movie)
            {
                List<SqlParameter> movies = new List<SqlParameter>();
                movies.Add(new SqlParameter("@movieTitle", movie.MovieTitle));
                movies.Add(new SqlParameter("@movieduration", movie.MovieDuration));
                movies.Add(new SqlParameter("@movieRating", movie.MovieRating));
                movies.Add(new SqlParameter("@directorId", movie.DirectorId));
                movies.Add(new SqlParameter("@movieId", movie.MovieId));
                try
                {
                    NonQuery(qMovie, movies.ToArray(), CommandType.StoredProcedure);
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void DeleteMovie(int id)
            {
                throw new NotImplementedException();
            }
            public List<Actor> DisplayAllActor()
            {
                throw new NotImplementedException();
            }
            public List<Director> DisplayAllDirectors()
            {
                throw new NotImplementedException();
            }

            public List<Movie> DisplayAllMovies()
            {
                throw new NotImplementedException();
            }
            public void UpateMovie(Movie movie)
            {
                List<SqlParameter> uMovie = new List<SqlParameter>();
                uMovie.Add(new SqlParameter("@movieTitle", movie.MovieTitle));
                uMovie.Add(new SqlParameter("@movieduration", movie.MovieDuration));
            uMovie.Add(new SqlParameter("@movieRating", movie.MovieRating));
                uMovie.Add(new SqlParameter("@movieId", movie.MovieId));
                try
                {
                    NonQuery(updateM, uMovie.ToArray(), CommandType.Text);
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            

            public void UpdateActor(Actor actor)
            {
                List<SqlParameter> uActor = new List<SqlParameter>();
                uActor.Add(new SqlParameter("@actorName", actor.ActorName));
                uActor.Add(new SqlParameter("@actorAge", actor.ActorAge));
                uActor.Add(new SqlParameter("@actorDesc", actor.ActorDesc));
                uActor.Add(new SqlParameter("@actorId", actor.ActorId));
                try
                {
                    NonQuery(updateA, uActor.ToArray(), CommandType.Text);
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void UpdateDirector(Director director)
            {
                List<SqlParameter> uDir = new List<SqlParameter>();
                uDir.Add(new SqlParameter("@directorName", director.DirectorName));
                uDir.Add(new SqlParameter("@directorAge", director.DirectorAge));
                uDir.Add(new SqlParameter("@directorId", director.DirectorId));
                try
                {
                    NonQuery(updateA, uDir.ToArray(), CommandType.Text);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public List<Entry> DisplayAllEntry()
            {
                throw new NotImplementedException();
            }
            #endregion
        }
    }
    class E2EMovieApp
    {
        static IMovieDatabase component = null;
        static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        static void Main(string[] args)
        {
            component = new MovieData(connectionString);
            //component.AddDirector(new Director
            //{
            //    DirectorName = Utility.Utilities.Prompt("Enter The director name :"),

            //    DirectorAge = Utility.Utilities.GetNumber("Entre Age : ")
            //});
            //Console.WriteLine("Diretor Added successfully");

            //component.AddMovie(new Movie
            //{
            //    MovieTitle = Utility.Utilities.Prompt("enter movie name : "),
            //    MovieDuration = Utility.Utilities.Prompt("enter movie duration : "),
            //    MovieRating = Utility.Utilities.GetNumber("enter movie rating : "),
            //    DirectorId = Utility.Utilities.GetNumber("enter the director id")
            //});
            //Console.WriteLine("Movie Added successfully");
            //component.AddActor(new Actor
            //{
            //    ActorName = Utility.Utilities.Prompt("Enter Actor Name"),
            //    ActorAge = Utility.Utilities.GetNumber("Enter Actor Age"),
            //    ActorDesc = Utility.Utilities.Prompt("Enter Description"),
            //});
            //Console.WriteLine("Actor Added successfully");
            //component.AddEntry(new Entry
            //{
            //    MovieId = Utility.Utilities.GetNumber("Enter Movie Id"),
            //    ActorId = Utility.Utilities.GetNumber("Enter Actor Id")
            //});
            //Console.WriteLine("Entry Added successfully");
        }
    }
}


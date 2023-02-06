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

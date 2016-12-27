using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;
using Models.Interfaces;

namespace Data
{
   public class DapperMovieRepo : IMovie
    {
        public void Update(Movie movie)
        {

            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("Id", movie.Id);
                p.Add("Title", movie.Title);
                p.Add("Genre", movie.Genre);
                p.Add("ReleaseDate", movie.ReleaseDate);
                p.Add("UserRating", movie.UserRating);
                p.Add("MPAARating", movie.MPAARating);
                p.Add("Director", movie.Director);
                p.Add("Actors", movie.Actors);
                p.Add("Studio", movie.Studio);
                p.Add("UserNotes", movie.UserNotes);
                p.Add("BorrowerId", movie.BorrowerId);
                p.Add("DateBorrowed", movie.DateBorrowed);
                p.Add("DateReturned", movie.DateReturned);

                conn.Execute("MovieUpdate", p, commandType: CommandType.StoredProcedure);   
            }
        }

        public bool Add(Movie movie)
        {
            var affectedRow = 0;

            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                 p.Add("Title", movie.Title);
               // p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);
                p.Add("Genre", movie.Genre);
                p.Add("ReleaseDate", movie.ReleaseDate);
                p.Add("UserRating", movie.UserRating);
                p.Add("MPAARating", movie.MPAARating);
                p.Add("Director", movie.Director);
                p.Add("Actors", movie.Actors);
                p.Add("Studio", movie.Studio);
               
                p.Add("UserNotes", movie.UserNotes);

               affectedRow = conn.Execute("MovieInsert", p, commandType: CommandType.StoredProcedure);

                //int movieId = p.Get<int>("Id");
                //movie.Id = movieId;
            }
            return affectedRow > 0;
        }

 

        public Movie GetById(int id)//how to return single movie
        {
            var movies = new Movie();
            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("Id", id);
                 movies = conn.Query<Movie>("SELECT * FROM Movies WHERE Id = @Id", p).FirstOrDefault();
            }
            return movies;
        }

        public List<Movie> LoadMovies()
        {
            var movies = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                 movies = conn.Query<Movie>("SELECT * FROM Movies").ToList();
               
            }
            return movies;
        }

        public bool Remove(int id)
        {
            var affectedRow = 0;
            using (SqlConnection conn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("Id", id);
               affectedRow = conn.Execute("DELETE FROM Movies WHERE Id = @Id", p);

            }
            return affectedRow > 0;
        }

        
    }
}

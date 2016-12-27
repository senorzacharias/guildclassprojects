using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace BLL
{
    public class Factory
    {
        private static string _borrowerFilePath = @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\DVDLibrary\BorrowersRepo\Borrowers.txt";

        private static string _movieFilePath =
            @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\DVDLibrary\MoviesRepo\Movies.txt";

        private static string _statusFilePath =
            @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\DVDLibrary\StatusRepo\Status.txt";
        public static Manager Create()
        {
            MovieRepository movieRepo = new MovieRepository();
            BorrowerRepository borrowerRepo = new BorrowerRepository();
            StatusRepository statusRepo = new StatusRepository();
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "Test":
                   

                    return new Manager(statusRepo, movieRepo, borrowerRepo);
                case "Prod":
                    FileMovieRepository movie = new FileMovieRepository(_movieFilePath);
                    FileBorrowerRepository borrower = new FileBorrowerRepository(_borrowerFilePath);
                    FileStatusRepository status = new FileStatusRepository(_statusFilePath);
                    return new Manager(status, movie, borrower);
                case "Dapper":
                    DapperMovieRepo dapperRepo = new DapperMovieRepo();
                    
                  return new Manager(statusRepo, dapperRepo, borrowerRepo);
                default:
                    throw new Exception("Check your mode! Greetings from the factory.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;
using Models.Responses;

namespace BLL
{
    public class Manager
    {
        private IStatus _statusRepository;
        private IMovie _movieRepository;
        private IBorrower _borrowerRepository;

        public Manager(IStatus statusRepository, IMovie movieRepository, IBorrower borrowerRepository)
        {
            _statusRepository = statusRepository;
            _movieRepository = movieRepository;
            _borrowerRepository = borrowerRepository;
        }

        
      


        /// ///////////////////////////MOVIE REPO/////////////////////////////

        public MovieLoadResponse MoviesLoad()
        {
            MovieLoadResponse response = new MovieLoadResponse();

            response.Movies = _movieRepository.LoadMovies();
            
            if (response.Movies.Count < 1)
            {
                response.Success = false;
                response.Message = "Error loading movies.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public AddMovieResponse AddMovie(Movie movie)
        {
            AddMovieResponse response = new AddMovieResponse();
            var firstLoad = _movieRepository.LoadMovies();

            if (string.IsNullOrEmpty(movie.Title) || string.IsNullOrEmpty(movie.Actors) ||
                string.IsNullOrEmpty(movie.Director) || string.IsNullOrEmpty(movie.MPAARating))
            {
                response.Success = false;
                response.Message = "Error adding movie. Fields cannot be empty.";

            }
            else
            {
                //movie.Id = firstLoad.Count + 1;
                _statusRepository.AddAvailable(movie);
                _movieRepository.Add(movie);
                var secondLoad = _movieRepository.LoadMovies().Count;
                if (firstLoad.Count >= secondLoad)
                {
                    response.Success = false;
                    response.Message = "Error loading movie to Movie Repo. Count does not indicate success.";
                }
                else
                {
                    response.Success = true;
                }
                
            }
            return response;
        }

        public RemoveMovieResponse RemoveMovie(int id)
        {
            RemoveMovieResponse response = new RemoveMovieResponse();

            var loadedMovies = _movieRepository.LoadMovies();
            var selected = loadedMovies.FirstOrDefault(i => i.Id == id);

            if (selected != null)
            {
                _movieRepository.Remove(id);

                if (loadedMovies.Count >= _movieRepository.LoadMovies().Count)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error removing movie.";
                }
            }
            else
            {
                response.Success = false;
            }


            return response;
        }

        public UpdateMovieResponse UpdateMovie(Movie movie)
        {
            UpdateMovieResponse response = new UpdateMovieResponse();
            var loaded = _movieRepository.LoadMovies().FirstOrDefault(i => i.Id == movie.Id);

            if (loaded == null)
            {
                response.Success = false;
                response.Message = "Error updating movie. Movie was not found.";

                return response;
            }

            if (movie.DateBorrowed == null)
            {
                movie.DateBorrowed = DateTime.Now;
            }
            else
            {
                if (movie.DateBorrowed < movie.DateReturned)
                {
                    movie.DateBorrowed = DateTime.Now;
                }
                else
                {
                    
                    movie.DateReturned = DateTime.Now;
                }
                    
                   
            }
            
             _movieRepository.Update(movie);


            if (loaded.BorrowerId == movie.BorrowerId && loaded.DateBorrowed == movie.DateBorrowed &&
                loaded.DateReturned == movie.DateReturned)
            {
                response.Success = true;
            }




            return response;
        }

        /////////////////////////////////////BORROWER REPO ///////////////////////////////////////

        public BorrowerLoadResponse BorrowersLoad()
        {
            BorrowerLoadResponse response = new BorrowerLoadResponse();

            response.Borrowers = _borrowerRepository.LoadBorrowers();

            if (response.Borrowers.Count < 1)
            {
                response.Success = false;
                response.Message = "Error loading borrowers.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public AddBorrowerResponse BorrowerAdd(Borrower borrower)
        {
            AddBorrowerResponse response = new AddBorrowerResponse();
            _borrowerRepository.Add(borrower);

            var firstLoad = _borrowerRepository.LoadBorrowers();
            if (string.IsNullOrEmpty(borrower.Name))
            {
                response.Success = false;
                response.Message = "Error adding bowser. Fields cannot be empty.";
            }
            else
            {
                _borrowerRepository.Add(borrower);
                if (_borrowerRepository.LoadBorrowers().Count <= firstLoad.Count)
                {
                    response.Success = false;
                    response.Message = "Error adding bowser. Count does not indicate success.";
                }
                else
                {
                    response.Success = true;
                }
            }
            return response;


        }

        //////////////////////////////////////////////////// STATUS REPO///////////////////////////////


        //public AddMovieResponse AddAvailableMovie(int id)
        //{
        //    AddMovieResponse response = new AddMovieResponse();
        //    var loadedMovie = _statusRepository.LoadAvailable().FirstOrDefault(i => i.Id == id);
        //    var updateSelected = _movieRepository.LoadMovies().FirstOrDefault(i => i.Id == id);
        //    if (loadedMovie != null)
        //    {
        //        response.Success = false;
        //        response.Message = "Captain, we have a boat in our port.";
        //        return response;
        //    }
        //    else
        //    {
        //        response.Success = true;
        //        updateSelected.BorrowerId = 0;
        //        _statusRepository.AddAvailable(updateSelected);
        //        _movieRepository.EditDateReturned(updateSelected);
        //    }
            
               
        //    return response;
        //}

       
        //public RemoveMovieResponse RemoveAvailableMovie(Movie movie)//fix
        //{
        //    RemoveMovieResponse response = new RemoveMovieResponse();
        //    var movieToBorrow = _statusRepository.LoadAvailable().FirstOrDefault(i => i.Id == movie.Id);
        //    var firstLoad = _statusRepository.LoadAvailable();
        //    if (movieToBorrow == null || movieToBorrow.BorrowerId != 0)
        //    {
        //        response.Success = false;
        //        response.Message = "Movie is currently out of stock.";
        //        return response;
        //    }
        //    else
        //    {
        //        _statusRepository.RemoveAvailable(movie.Id);
        //        //movieToBorrow.BorrowerId = movie.BorrowerId;
        //        _movieRepository.EditDateBorrowed(movie);
        //        if (_statusRepository.LoadAvailable().Count >= firstLoad.Count)
        //        {
        //            response.Success = false;
        //            response.Message = "Error Renting movie.";
        //            return response;
        //        }
        //        else
        //        {
        //            response.Success = true;
        //        }
        //    }

        //    return response;
            
        //}

        //private MovieLoadResponse LoadAvailableMovies()
        //{
        //    MovieLoadResponse response = new MovieLoadResponse();

        //    response.Movies = _statusRepository.LoadAvailable();

        //    if (response.Movies.Count < 1)
        //    {
        //        response.Success = false;
        //        response.Message = "Error loading available orders.";
        //    }
        //    else
        //    {
        //        response.Success = true;
        //    }
        //    return response;
        //}

    }
}

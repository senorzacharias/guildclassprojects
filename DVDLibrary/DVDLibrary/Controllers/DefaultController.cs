using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DVDLibrary.Models;
using Models;

namespace DVDLibrary.Controllers
{
    public class DefaultController : Controller
    {
        Manager manager = Factory.Create();

        

        public ActionResult ApiPractice()
        {
            return View();
        }

        public ActionResult LookupMovie()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult ManageCustomers()
        {
            MovieVM viewModel = new MovieVM();
            
            viewModel.Iborrowers = manager.BorrowersLoad().Borrowers;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ManageCustomers(MovieVM modelVm)
        {
            Borrower model = new Borrower();

            model.Name = modelVm.Borrower.Name;
            model.City = modelVm.Borrower.City;
            model.EmailAddress = modelVm.Borrower.EmailAddress;
            model.StreetName = modelVm.Borrower.StreetName;
            model.ZipCode = modelVm.Borrower.ZipCode;

            manager.BorrowerAdd(model);

            return RedirectToAction("ManageCustomers");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewMovies()
        {
            MovieVM viewModel = new MovieVM();
            viewModel.Movies = manager.MoviesLoad().Movies;
            
            return View(viewModel);
        }

        [HttpPut]
        public ActionResult ViewMovies(MovieVM modelVm)
        {
            //Movie model = new Movie();
            //model.Id = modelVm.Movie.Id;
            //model.BorrowerId = modelVm.Movie.BorrowerId;
            //manager.RemoveAvailableMovie(model);
           
           

            return RedirectToAction("ViewMovies");
        }


        [HttpGet]
        public ActionResult ViewOneMovie(int id)
        {
            MovieVM model = new MovieVM();
            model.Movie = manager.MoviesLoad().Movies.SingleOrDefault(i => i.Id == id);


            return View(model);
        }


        [HttpGet]
        public ActionResult ManageMovies()
        {
            MovieVM viewModel = new MovieVM();
            viewModel.Movies = manager.MoviesLoad().Movies;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ManageMovies(MovieVM modelVm)//MovieVM modelVm
        {
            Movie model = new Movie();



            var movie = manager.MoviesLoad().Movies.FirstOrDefault(i => i.Id == modelVm.Movie.Id);

            if (movie != null)
            {
                return RedirectToAction("ManageMovies");
            }
           
                model.Title = modelVm.Movie.Title.ToLower();
                model.Actors = modelVm.Movie.Actors;
                model.Director = modelVm.Movie.Director;
                model.Genre = modelVm.Movie.Genre;
                model.MPAARating = modelVm.Movie.MPAARating;
                model.Studio = modelVm.Movie.Studio;
                model.ReleaseDate = modelVm.Movie.ReleaseDate;
                model.UserNotes = modelVm.Movie.UserNotes;
                model.UserRating = modelVm.Movie.UserRating;

                manager.AddMovie(model);
         


            return RedirectToAction("ManageMovies");
        }

        [HttpGet]
        public ActionResult AddMovies()
        {
            MovieVM model = new MovieVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMovies(MovieVM modelVm)
        {
            Movie model = new Movie();

            model.Title = modelVm.Movie.Title;
            model.Actors = modelVm.Movie.Actors;
            model.Director = modelVm.Movie.Director;
            model.Genre = modelVm.Movie.Genre;
            model.MPAARating = modelVm.Movie.MPAARating;
            model.Studio = modelVm.Movie.Studio;
            model.ReleaseDate = modelVm.Movie.ReleaseDate;
            model.UserNotes = modelVm.Movie.UserNotes;
            model.UserRating = modelVm.Movie.UserRating;

            manager.AddMovie(model);

            return RedirectToAction("Index");
        }

      

        [HttpDelete]
        public JsonResult DeleteMovie(int id) //backwards-needs to add available movie
        {
            JsonResult result = new JsonResult();
            manager.RemoveMovie(id);

            return result;
        }
    }
}


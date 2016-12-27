using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Models;
using BLL;

namespace DVDLibrary.Controllers
{
    public class HomeController : ApiController
    {
        private Manager manager = Factory.Create();

        public List<Movie> Get()
        {

            return manager.MoviesLoad().Movies;

        }

        public Movie Get(int id)
        {
            return manager.MoviesLoad().Movies.FirstOrDefault(i => i.Id == id);

        }

        public HttpResponseMessage Post(Movie newMovie)
        {
            manager.AddMovie(newMovie);

            var response = Request.CreateResponse(HttpStatusCode.Created, newMovie);

            string uri = Url.Link("DefaultApi", new {id = newMovie.Id});
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public HttpResponseMessage Put(Movie movie)
        {
            manager.UpdateMovie(movie);

            var response = Request.CreateResponse(HttpStatusCode.Created, movie);
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            manager.RemoveMovie(id);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, id);
            return response;
        }

    }
}

using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StatusRepository : IStatus
    {
        private static List<Movie> _available;
        private static List<Movie> _rented;

        static StatusRepository()
        {
            _available = new List<Movie>();
            _rented = new List<Movie>();


            Movie movie1 = new Movie
            {
                Id = 6,
                Title = "Modern Times",
                ReleaseDate = "August 8th, 1939",
                MPAARating = "PG",
                Director = "Charlie Chaplin",
                Studio = "United Artists",
                UserRating = 4.4,
                UserNotes =
                    "Chaplin's loneliness was relieved when he met 21-year-old actress Paulette Goddard in July 1932," +
                    " and the pair began a successful relationship.[196] He was not ready to commit to a film, however," +
                    " and focussed on writing a serial about his travels (published in Woman's Home Companion).[197]" +
                    " The trip had been a stimulating experience for Chaplin, including meetings with several prominent " +
                    "thinkers, and he became increasingly interested in world affairs.[198] The state of labour in America" +
                    " troubled him, and he feared that capitalism and machinery in the workplace would increase unemployment " +
                    "levels. It was these concerns that stimulated Chaplin to develop his new film.",
                BorrowerId = 5
            };

            Movie movie2 = new Movie
            {
                Id = 6,
                Title = "Gladiator",
                ReleaseDate = "May 5th, 2000",
                MPAARating = "PG",
                Director = "Charlie Chaplin",
                Studio = "United Artists",
                UserRating = 4.4,
                UserNotes =
                   "Chaplin's loneliness was relieved when he met 21-year-old actress Paulette Goddard in July 1932," +
                   " and the pair began a successful relationship.[196] He was not ready to commit to a film, however," +
                   " and focussed on writing a serial about his travels (published in Woman's Home Companion).[197]" +
                   " The trip had been a stimulating experience for Chaplin, including meetings with several prominent " +
                   "thinkers, and he became increasingly interested in world affairs.[198] The state of labour in America" +
                   " troubled him, and he feared that capitalism and machinery in the workplace would increase unemployment " +
                   "levels. It was these concerns that stimulated Chaplin to develop his new film.",
                BorrowerId = 2
            };

            _available.Add(movie1);
            _rented.Add(movie2);
        }

        public void AddAvailable(Movie movie)
        {
            _available.Add(movie);
        }

        public void AddRented(Movie movie)
        {
            _rented.Add(movie);
        }

        public List<Movie> LoadAvailable()
        {
            return _available;
        }

        public List<Movie> LoadRented()
        {
            return _rented;
        }

        public void RemoveAvailable(int id)
        {
            _available.RemoveAll(i => i.Id == id);
        }

        public void RemoveRented(int id)
        {
            _rented.RemoveAll(i => i.Id == id);
        }
    }
}

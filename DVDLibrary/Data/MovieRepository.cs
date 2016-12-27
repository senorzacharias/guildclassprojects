using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Data
{
    public class MovieRepository : IMovie
    {
        private static List<Movie> _movies;

        static MovieRepository()
        {
            _movies = new List<Movie>();

            Movie movie1 = new Movie
            {
                Id = 1,
                Title = "The General",
                ReleaseDate = "March 3rd, 1926",
                Genre = "Adventure",
                MPAARating = "PG",
                Director = "Buster Keaton",
                Studio = "MGM",
                UserRating = 4.5,
                UserNotes =
                    "The General is a 1926 American silent comedy film released by United Artists. Inspired by the Great Locomotive Chase," +
                    " which happened in 1862, the film stars Buster Keaton who co-directed it with Clyde Bruckman." +
                    " It was adapted by Al Boasberg, Bruckman, Keaton, Paul Girard Smith and Charles Henry Smith from the memoir The Great Locomotive Chase by William Pittenger.",
                Actors = "Bustor Keaton(Johnnie Gray), Marion Mack(Annabelle Lee), Glen Cavender(Captain Anderson)",
                BorrowerId = 1
            };

            Movie movie2 = new Movie
            {
                Id = 2,
                Title = "City Lights",
                ReleaseDate = "December 12th, 1939",
                Genre = "Adventure",
                MPAARating = "PG",
                Director = "Charlie Chaplin",
                Studio = "United Artists",
                UserRating = 4.2,
                UserNotes =
                    "City Lights is a 1931 American pre-Code silent romantic comedy film written, directed by, and starring Charlie Chaplin." +
                    " The story follows the misadventures of Chaplin's Tramp as he falls in love with a blind girl (Virginia Cherrill) and develops" +
                    " a turbulent friendship with an alcoholic millionaire (Harry Myers).",
                BorrowerId = 2
            };

            Movie movie3 = new Movie
            {
                Id = 3,
                Title = "The Great Dictator",
                ReleaseDate = "February 2nd, 1939",
                Genre = "Adventure",
                MPAARating = "PG",
                Director = "Charlie Chaplin",
                Studio = "United Artists",
                UserRating = 4.2,
                UserNotes =
                    "The 1940s saw Chaplin face a series of controversies, both in his work and in his personal life," +
                    " which changed his fortunes and severely affected his popularity in the United States. " +
                    "The first of these was a new boldness in expressing his political beliefs." +
                    " Deeply disturbed by the surge of militaristic nationalism in 1930s world politics,[213] Chaplin found that he could not keep these issues out of his work.[214]" +
                    " Parallels between himself and Adolf Hitler had been widely noted: the pair were born four days apart," +
                    " both had risen from poverty to world prominence, and Hitler wore the same toothbrush moustache as Chaplin." +
                    " It was this physical resemblance that supplied the plot for Chaplin's next film, The Great Dictator, " +
                    "which directly satirised Hitler and attacked fascism.[215]",
                BorrowerId = 3
            };

            Movie movie4 = new Movie
            {
                Id = 4,
                Title = "Limelight",
                ReleaseDate = "July 6th, 1952",
                Genre = "Adventure",
                MPAARating = "PG",
                Director = "Charlie Chaplin",
                Studio = "United Artists",
                UserRating = 2.8,
                UserNotes =
                    "Although Chaplin remained politically active in the years following the failure of Monsieur Verdoux,[note 21]" +
                    " his next film, about a forgotten vaudeville comedian and a young ballerina in Edwardian London, " +
                    "was devoid of political themes. Limelight was heavily autobiographical, alluding not only to Chaplin's " +
                    "childhood and the lives of his parents, but also to his loss of popularity in the United States.[274] " +
                    "The cast included various members of his family, including his five oldest children and his half-brother," +
                    " Wheeler Dryden.[275]",
                BorrowerId = 4

            };

            Movie movie5 = new Movie
            {
                Id = 5,
                Title = "Modern Times",
                ReleaseDate = "August 11th, 1936",
                Genre = "Adventure",
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

            _movies.Add(movie5);
            _movies.Add(movie4);
            _movies.Add(movie3);
            _movies.Add(movie2);
            _movies.Add(movie1);

        }


        public List<Movie> LoadMovies()
        {
            return _movies;
        }

        public void Add(Movie movie)
        {
            movie.Id = _movies.Max(i => i.Id + 1);
            _movies.Add(movie);
        }

        public void Remove(int id)
        {
            _movies.RemoveAll(i => i.Id == id);
        }

        public void EditDateBorrowed(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void EditDateReturned(Movie movie)
        {
            throw new NotImplementedException();
        }

        bool IMovie.Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        bool IMovie.Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}

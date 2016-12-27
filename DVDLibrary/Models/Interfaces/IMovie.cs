using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IMovie
    {
        List<Movie> LoadMovies();
        bool Add(Movie movie);
        bool Remove(int id);
        void Update(Movie movie);

    }
}

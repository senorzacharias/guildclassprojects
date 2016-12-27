using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IStatus
    {
        void AddAvailable(Movie movie);
        void RemoveAvailable(int id);
        List<Movie> LoadAvailable();
      
    }
}

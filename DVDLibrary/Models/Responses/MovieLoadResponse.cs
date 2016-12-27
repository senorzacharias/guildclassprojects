using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class MovieLoadResponse : Response
    {
        public List<Movie> Movies { get; set; }
    }

   
}

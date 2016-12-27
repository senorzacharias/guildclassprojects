using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;
using System.Web.Mvc;
using Models;

namespace DVDLibrary.Models
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }
        public Borrower Borrower { get; set; }
        public List<Borrower> Borrowers { get; set; }
        public IEnumerable<Borrower> Iborrowers { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }
        
        
        


        public MovieVM()
        {
            
            Movies = new List<Movie>();
            Movie = new Movie();
            Borrower = new Borrower();
            CategoryItems = Enum.GetNames(typeof(Genre)).Select(i => new SelectListItem() {Text = i}).ToList();
        }
    }
}

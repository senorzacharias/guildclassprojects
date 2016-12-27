using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{//more than one entry note on DVD
    // add borrower notes that can be viewed on details page\
    //add categories for search results
    //search movies by release year
    //list of available movies
    //list of rented movies
    // USE IMDB API
    [DataContract]
   public class Movie
    {
       [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter a Title")]
        public string Title { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter a Release Date")]
        public string ReleaseDate { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter a Genre")]
        public string Genre { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter a MPAA Rating")]
        public string MPAARating { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter a Director")]
        public string Director { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter a Studio")]
        public string Studio { get; set; }
        [DataMember]
        [Range(1,10, ErrorMessage = "Number must be between {1} and {2}.")]
        public double UserRating { get; set; }
        [DataMember]
        [StringLength(int.MaxValue, MinimumLength = 15, ErrorMessage = "Please add a more detailed description.")]
        public  string UserNotes { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter Actors")]
        public string Actors { get; set; }
        [DataMember]
        //[Required(ErrorMessage = "Please enter a Customer Id#")]
        public int? BorrowerId  { get; set; }
        [DataMember]
        public DateTime? DateBorrowed { get; set; }
        [DataMember]
        public DateTime? DateReturned { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Applicant
    {

       
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Name must be more than two characters.")]
        public string ApplicantName { get; set; }
        [Required(ErrorMessage = "Please enter email.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@([A-Za-z0-9-]+\.)+([A-Za-z0-9]{2,4}|museum)$", ErrorMessage = "Please enter valid email.")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Please enter street number.")]
        public int StreetNumber { get; set; }
        [Required(ErrorMessage = "Please enter street name.")]
        public string StreetName { get; set; }
        [Required(ErrorMessage = "Please enter city.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter zipcode.")]
        public int ZipCode { get; set; }
        [Required(ErrorMessage = "Please enter employer.")]
        public string Employer { get; set; }
        [Required(ErrorMessage = "Please add job description.")]
        public string JobDescription { get; set; }
        
    }
}

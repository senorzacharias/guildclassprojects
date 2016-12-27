using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{//more than one entry note on DVD
    
    // add borrower notes that can be viewed on details page
   [DataContract]
    public class Borrower
    {
        [DataMember]
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Name must be more than two characters.")]
        public string Name { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter email.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@([A-Za-z0-9-]+\.)+([A-Za-z0-9]{2,4}|museum)$", ErrorMessage = "Please enter valid email.")]
        public string EmailAddress { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter street number.")]
        public int StreetNumber { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter street name.")]
        public string StreetName { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter city.")]
        public string City { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Please enter zipcode.")]
        public int ZipCode { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Movie { get; set; }
       
       
    }
}

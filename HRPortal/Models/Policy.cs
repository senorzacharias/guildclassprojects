using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Policy 
    {
        
        public int PolicyNumber { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Name must be more than two characters.")]
        public string PolicyName { get; set; }
        [Required(ErrorMessage = "Please enter policy description.")]
        [StringLength(int.MaxValue, MinimumLength = 15, ErrorMessage = "Please add a more detailed description.")]
        public string PolicyContent { get; set; }
        public int CategoryId { get; set; }
    }
}

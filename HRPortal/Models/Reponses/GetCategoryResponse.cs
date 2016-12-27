using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Reponses
{
    public class GetCategoryResponse : Response
    {
        public Category Category { get; set; }
    }
}

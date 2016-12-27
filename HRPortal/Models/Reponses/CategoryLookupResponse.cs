using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Reponses
{
    public class CategoryLookupResponse : Response
    {
        public List<Category> Categories { get; set; }
    }
}

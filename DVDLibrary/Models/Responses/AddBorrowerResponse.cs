using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class AddBorrowerResponse : Response
    {
        public Borrower NewBorrower { get; set; }
    }
}

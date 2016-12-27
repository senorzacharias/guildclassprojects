using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
    public class ApplicationVM 
    {
            public Applicant Applicant { get; set; }
            
            public ApplicationVM()
            {
              Applicant = new Applicant();
            }
        }
}

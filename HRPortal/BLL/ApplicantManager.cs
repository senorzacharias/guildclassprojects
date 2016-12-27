using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace BLL
{
    public class ApplicantManager
    {
        private ApplicationFileRepository _applicationFile = new ApplicationFileRepository();

        public void AddApplicant(ApplicationVM applicant)
        {
            _applicationFile.Add(applicant);
        }
    }
}

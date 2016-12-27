using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class ApplicationFileRepository
    {
        private string _filePath = @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\HRPortal\ApplicantIO\Applications.txt";
        public void Add(ApplicationVM model)
        {

            

            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                sw.WriteLine();
                sw.WriteLine(model.Applicant.ApplicantName);
                sw.WriteLine(model.Applicant.EmailAddress);
                sw.WriteLine(model.Applicant.StreetNumber);
                sw.WriteLine(model.Applicant.StreetName);
                sw.WriteLine(model.Applicant.City);
                sw.WriteLine(model.Applicant.ZipCode);
                sw.WriteLine(model.Applicant.Employer);
                sw.WriteLine(model.Applicant.JobDescription);
            }

            
        }

    }
}

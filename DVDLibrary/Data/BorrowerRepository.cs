using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Data
{
    public class BorrowerRepository : IBorrower
    {
        private static List<Borrower> _borrowers;

        static BorrowerRepository()
        {
            _borrowers = new List<Borrower>();

            Borrower borrower1 = new Borrower
            {
                Name = "Andres Segovia",
                Movie = "Hercules"
                //DateBorrowed = new DateTime(2016, 7, 11),
                //DateReturned = new DateTime(2016, 8, 16)
            };

            Borrower borrower2 = new Borrower
            {
                Name = "Curious George",
                Movie = "Lion King"
                //DateBorrowed = new DateTime(2015, 1, 3),
                //DateReturned = new DateTime(2016, 9, 10)
            };

            Borrower borrower3 = new Borrower
            {
                Name = "Scipio Africanus",
                Movie = "Ben-Hur"
                //DateBorrowed = new DateTime(2016, 3, 1),
                //DateReturned = new DateTime(2016, 5, 16)
            };

            Borrower borrower4 = new Borrower
            {
                Name = "Marcus Aurelius",
                Movie = "Robin Hood"
                //DateBorrowed = new DateTime(2016, 7, 11),
                //DateReturned = new DateTime(2016, 9, 16)
            };

            Borrower borrower5 = new Borrower
            {
                Name = "William Faulkner",
                Movie ="As I Stand Living"
                //DateBorrowed = new DateTime(2016, 10, 11),
                //DateReturned = new DateTime(2016, 10, 16)
            };

            _borrowers.Add(borrower5);
            _borrowers.Add(borrower4);
            _borrowers.Add(borrower3);
            _borrowers.Add(borrower2);
            _borrowers.Add(borrower1);

        }

        public void Add(Borrower borrower)
        {
            borrower.Id = _borrowers.Max(i => i.Id) + 1;
            _borrowers.Add(borrower);
        }

        public List<Borrower> LoadBorrowers()
        {
            return _borrowers;
        }
    }
}

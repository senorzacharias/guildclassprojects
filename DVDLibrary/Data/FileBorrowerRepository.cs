using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Data
{
    public class FileBorrowerRepository : IBorrower
    {
        private string _FILEPATH =
            @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\DVDLibrary\MoviesRepo\Borrowers.txt";

        private string _filePath;

        public FileBorrowerRepository(string filepath)
        {
            _filePath = filepath;


        }

        public void Add(Borrower borrower)
        {
            List<Borrower> list = new List<Borrower>();

            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                DataContractJsonSerializer jserial = new DataContractJsonSerializer(typeof(List<Borrower>));
                list = (List<Borrower>)jserial.ReadObject(fs);
            }

            borrower.Id = list.Count + 1;
            borrower.Name = borrower.Name.ToLower();
            list.Add(borrower);

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Borrower>));

            using (FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            {
                js.WriteObject(fs, list);

            }
        }

        public List<Borrower> LoadBorrowers()
        {
            List<Borrower> borrowerList = new List<Borrower>();
            try
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Borrower>));
                    borrowerList = (List<Borrower>)js.ReadObject(fs);
                }
                return borrowerList;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }

            return borrowerList;
        }



        public void Remove(int id)
        {
            List<Borrower> list = new List<Borrower>();
            Borrower borrower = new Borrower();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Movie>));

            using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                 list = (List<Borrower>)js.ReadObject(fs);

                borrower = list.FirstOrDefault(i => i.Id == id);
            }

            list.Remove(borrower);
            DataContractJsonSerializer jser = new DataContractJsonSerializer(typeof(List<Movie>));

            using (FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            {
                jser.WriteObject(fs, list);

            }
        }
    }
}



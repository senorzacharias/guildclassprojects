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
    public class FileStatusRepository : IStatus
    {
        
        private static string _filePath;

        public FileStatusRepository(string filePath)
        {
            _filePath = filePath;
        }



        public void AddAvailable(Movie movie)
        {
            List<Movie> movieList = new List<Movie>();

            using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                DataContractJsonSerializer jserial = new DataContractJsonSerializer(typeof(List<Movie>));
                movieList = (List<Movie>)jserial.ReadObject(fs);
            }
            
            movieList.Add(movie);

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Movie>));

            using (FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            {
                js.WriteObject(fs, movieList);

            }
        }

       

        public List<Movie> LoadAvailable()
        {
            List<Movie> movieList = new List<Movie>();
            try
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Movie>));
                    movieList = (List<Movie>)js.ReadObject(fs);
                }
                return movieList;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }

            return movieList;
        }

      
        public void RemoveAvailable(int id)
        {
            Movie movie = new Movie();
            List<Movie> list = new List<Movie>();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Movie>));

            using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                list = (List<Movie>)js.ReadObject(fs);

                movie = list.FirstOrDefault(i => i.Id == id);
            }
            list.Remove(movie);

            DataContractJsonSerializer jser = new DataContractJsonSerializer(typeof(List<Movie>));

            using (FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            {
                jser.WriteObject(fs, list);

            }
        }

       
    }
}

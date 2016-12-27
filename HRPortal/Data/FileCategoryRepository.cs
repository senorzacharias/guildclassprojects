using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;
using System.IO;

namespace Data
{
    public class FileCategoryRepository : ICategoryRepository
    {
        //string CATEGORY_PATH =
        //    @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\HRPortal\CategoryIO";

        private  string _filePath;

        public FileCategoryRepository(string filePath)
        {
            _filePath = filePath;
        }

        public Category Add(string categoryName)
        {
            Category catchCategory = new Category();//sensible?functional?

            
                Category newCategory = new Category();
                List<Category> allCategories = GetAll();
                var existsCategory = allCategories.FirstOrDefault(c => c.CategoryName == categoryName);//try to use
                 newCategory.CategoryName = categoryName;

            if (File.Exists(_filePath))
                {
                    newCategory.CategoryId = allCategories.Count + 1;
                   
                }
                else
                {
                    newCategory.CategoryId = 1;
                    using (StreamWriter sw = new StreamWriter(_filePath))
                    {
                        sw.WriteLine("CategoryNumber,CategoryName");
                    }
                }

                using (StreamWriter sw = new StreamWriter(_filePath, true))
                {

                    string line = CreateOrderFormat(newCategory);

                    sw.WriteLine(line);
                }
                allCategories.Add(newCategory);
            
           
            return catchCategory;
        }

        public void Delete(int categoryId)
        {
            List<Category> loadedCategories = GetAll();
            var selectedCategory = loadedCategories.FirstOrDefault(i => i.CategoryId == categoryId);
            loadedCategories.Remove(selectedCategory);

            CreateOrderFile(loadedCategories);

        }

        public Category Get(int categoryId)//no need
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {

            List<Category> allCategories = new List<Category>();

            //if (File.Exists(_filePath))
            //{

                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Category newCategory = new Category();
                        string[] columns = line.Split(',');

                        newCategory.CategoryId = int.Parse(columns[0]);
                        newCategory.CategoryName = columns[1];

                        allCategories.Add(newCategory);
                    }
                }
            //}
            return allCategories;
        }

        public void CreateOrderFile(List<Category> categories)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.WriteLine("CategoryNumber,CategoryName");

                foreach (var category in categories)
                {
                    sw.WriteLine(CreateOrderFormat(category));
                }
            }
        }

        public string CreateOrderFormat(Category category)
        {
            return string.Format($"{category.CategoryId},{category.CategoryName}");

        }

    }
}


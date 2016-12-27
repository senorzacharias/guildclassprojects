using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private static List<Category> _categories;

        static CategoryRepository()
        {
            _categories = new List<Category>();
           

             Category cat1 = new Category
            {
                CategoryId = 1,
                CategoryName = "Animals"
            };

             Category cat2 = new Category
            {
                CategoryId = 2,
                CategoryName = "Harrassment"
            };

             Category cat3 = new Category
            {
                CategoryId = 3,
                CategoryName = "DressCode"
            };

             Category cat4 = new Category
            {
                CategoryId = 4,
                CategoryName = "Attendance"
            };

            _categories.Add(cat1);
            _categories.Add(cat2);
            _categories.Add(cat3);
            _categories.Add(cat4);
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category Get(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public Category Add(string categoryName)
        {
            Category category = new Category();
            category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
            category.CategoryName = categoryName;
            _categories.Add(category);

            return category;
        }

        public void Delete(int categoryId)
        {
            _categories.RemoveAll(c => c.CategoryId == categoryId);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Get(int categoryId);
        Category Add(string categoryName);
        void Delete(int categoryId);
    }
}

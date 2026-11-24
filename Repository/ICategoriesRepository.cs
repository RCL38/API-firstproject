using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ICategoriesRepository
    {
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetAllCategory();
    }
}

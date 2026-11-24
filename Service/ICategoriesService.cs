using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ICategoriesService
    {
        
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetAllCategory();



    }
}

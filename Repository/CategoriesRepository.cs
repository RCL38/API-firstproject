using Entity;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CategoriesRepository
    {
        private readonly storeDBContext _dbContext;

        public CategoriesRepository(storeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }
    }
}

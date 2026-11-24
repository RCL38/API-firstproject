using Entity;
using Repository;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    internal class CategoriesService
    {
        private readonly ICategoriesRepository repository;
        public CategoriesService(ICategoriesRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await repository.GetCategoryById(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await repository.GetAllCategory();
        }


    }
}

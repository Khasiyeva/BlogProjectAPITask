using BlogProject.Business.CategoryDTOs;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using BlogProject.DAL.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Category> Create(CategoryCreateDto Category)
        {
            if (Category == null) throw new Exception("Not null");
            Category Categorys = new Category()
            {
                Name = Category.Name,
            };
            await _repo.Create(Categorys);
            await _repo.SaveChangesAsync();
            return Categorys;

        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            var Categorys = await _repo.GetAllAsync();

            return await Categorys.ToListAsync();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

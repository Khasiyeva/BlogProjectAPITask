using BlogProject.Business.DTOs.AccountDTOs;
using BlogProject.Business.DTOs.CategoryDTOs;
using BlogProject.Business.Exceptions;
using BlogProject.Business.Exceptions.Account;
using BlogProject.Business.Exceptions.CategoryException;
using BlogProject.Business.Exceptions.Common;
using BlogProject.Business.Helpers;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using BlogProject.DAL.Repositories.Implementations;
using BlogProject.DAL.Repositories.Intefaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;


        public CategoryService(ICategoryRepository repo, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _repo = repo;
            _userManager = userManager;
            _env = env;
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

        

        public async Task<Category> GetByIdAsync(int id)
        {
            if (id <= 0) throw new NegativeIdException();

            Category category = await _repo.GetByIdAsync(id);
            if (category == null) throw new CategoryNullException();

            return category;
        }


        public async Task<bool> Register(RegisterDtos registerDtos)
        {
            AppUser appUser = new AppUser()
            {
                Name = registerDtos.Name,
                Surname = registerDtos.Surname,
                UserName = registerDtos.Username,
                Email = registerDtos.Email
            };

            var result = await _userManager.CreateAsync(appUser, registerDtos.Password);

            if (!result.Succeeded)
            {
                throw new RegisterFailException();
            }

            return true;
        }

        public async Task<bool> Update(CategoryUpdateDto categoryUpdatedto)
        {
            if (categoryUpdatedto.Id <= 0) throw new NegativeIdException();

            Category category = await _repo.GetByIdAsync(categoryUpdatedto.Id);

            if (category == null) throw new CategoryNullException();

            category.LogoUrl.DeleteFile(_env.WebRootPath, @"\Upload\Category\");

            category.LogoUrl = categoryUpdatedto.Logo.Upload(_env.WebRootPath, @"\Upload\Category\");
            if (categoryUpdatedto.Name != null)
            {
                category.Name = categoryUpdatedto.Name;
            }
            _repo.Update(category);
            int result = await _repo.SaveChangesAsync();

            if (result > 0) return true;
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0) throw new NegativeIdException();

            Category category = await _repo.GetByIdAsync(id);
            if (category == null) throw new CategoryNullException();
            category.LogoUrl.DeleteFile(_env.WebRootPath, @"\Upload\Category\");
            _repo.Delete(category);
            int result = await _repo.SaveChangesAsync();

            if (result > 0) return true;
            return false;
        }
    }
}

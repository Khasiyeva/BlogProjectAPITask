using BlogProject.Business.DTOs.AccountDTOs;
using BlogProject.Business.DTOs.CategoryDTOs;
using BlogProject.Business.Exceptions;
using BlogProject.Business.Exceptions.Account;
using BlogProject.Business.Exceptions.CategoryException;
using BlogProject.Business.Exceptions.Common;
using BlogProject.Business.ExternalService.Interfaces;
using BlogProject.Business.Helpers;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using BlogProject.DAL.Repositories.Implementations;
using BlogProject.DAL.Repositories.Intefaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly ITokenService _tokenService;

        public CategoryService(ICategoryRepository repo, UserManager<AppUser> userManager, IWebHostEnvironment env,ITokenService tokenService)
        {
            _repo = repo;
            _userManager = userManager;
            _env = env;
            _tokenService = tokenService;
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

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
            await _repo.SaveChangesAsync();
        }

        public async Task<TokenResponseDto> LoginAsync(LoginDto dto)
        {
            var user =await _userManager.FindByNameAsync(dto.UserNameOrEmail)?? await _userManager.FindByNameAsync(dto.UserNameOrEmail);
            if (user == null) 
                throw new UserNotFoundException();
            if (!await _userManager.CheckPasswordAsync(user, dto.Password)) ;
            throw new UserNotFoundException();

            return _tokenService.CreateToken(user);
        }

        
    }
}

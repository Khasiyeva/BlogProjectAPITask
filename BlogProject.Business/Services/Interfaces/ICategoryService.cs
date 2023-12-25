using BlogProject.Business.CategoryDTOs;
using BlogProject.Core.Entities;
using BlogProject.DAL.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Services.Interfaces
{
    public interface ICategoryService
    {
            Task<ICollection<Category>> GetAllAsync();
            Task<Category> GetByIdAsync(int id);
            Task<Category> Create(CategoryCreateDto Category);

        }

    }


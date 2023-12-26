using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.DTOs.CategoryDTOs
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? Logo { get; set; }
    }

    public class CategoryUpdateDtoValidation : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidation()
        {
            RuleFor(c => c.Id).
                NotNull().
                WithMessage("Id can't be null");

            RuleFor(c => c.Name).
                MaximumLength(55).
                WithMessage("Maxsimum length is 55");

            RuleFor(c => c.Logo).
                NotNull().
                WithMessage("Image can't be null");

        }
    }
}

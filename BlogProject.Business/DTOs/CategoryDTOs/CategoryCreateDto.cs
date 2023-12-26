using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.DTOs.CategoryDTOs
{
    public record CategoryCreateDto
    {
        public string? Name { get; set; }
        public IFormFile? Logo { get; set; }
    }

    public class CategoryCreateDtoValidation : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidation()
        {
            RuleFor(b => b.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Bos ola bilmez")
                .MaximumLength(55);
            RuleFor(b => b.Logo)
                .NotNull()
                .WithMessage("Sekil bos ola bilmez");
        }
    }
}

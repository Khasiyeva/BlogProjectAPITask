using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.DTOs.CategoryDTOs
{
    public class CategoryDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
    }

    public class CategoryDetailDtoValidation : AbstractValidator<CategoryDetailDto>
    {
        public CategoryDetailDtoValidation()
        {
            RuleFor(c => c.Id).
                NotNull().
                WithMessage("Can't be null");
            RuleFor(c => c.Name).
                NotNull().
                WithMessage("Name can't be null").
                NotEmpty().
                WithMessage("Name can't be null").
                MaximumLength(55).
                WithMessage("Maxsimum length is 55");

            RuleFor(c => c.LogoUrl).
                NotNull().
                WithMessage("Image can't be null");

        }
    }
}

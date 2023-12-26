using BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.DTOs.CategoryDTOs
{
    public record CategoryListItemDto
    {
        public List<Category> Categories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.DTOs.AccountDTOs
{
    public record TokenResponseDto
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}

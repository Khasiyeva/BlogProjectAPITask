﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.DTOs.AccountDTOs
{
    public record LoginDto
    {
        public string UserNameOrEmail {  get; set; }
        public string Password { get; set; }

    }

    public class LoginDtoValidation : AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(l => l.UserNameOrEmail)
                .NotEmpty()
                .WithMessage("Username/Email bos ola bilmez");
            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Password bos ola bilmez");
        }
    }

}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.DTOs.AccountDTOs
{
    public record RegisterDtos
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterDtosValidation : AbstractValidator<RegisterDtos>
    {
        public RegisterDtosValidation()
        {
            RuleFor(x => x.Name).
                NotEmpty().
                WithMessage("Name is required").
                MaximumLength(25).
                WithMessage("Maxsimum length is 25");

            RuleFor(x => x.Surname).
              NotEmpty().
              WithMessage("Surname is required").
              MaximumLength(25).
              WithMessage("Maxsimum length is 25");

            RuleFor(x => x.Username).
              NotEmpty().
              WithMessage("Username is required").
              MaximumLength(50).
              WithMessage("Maxsimum length is 50");

            RuleFor(x => x.Email).
                NotEmpty().
                WithMessage("Email address is required.").
                EmailAddress().
                WithMessage("A valid email address is required.");

            RuleFor(p => p.Password).
                NotEmpty().
                WithMessage("Password is required").
                Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.").
                Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");

            RuleFor(x => x.ConfirmPassword).
            NotEmpty().
            WithMessage("ConfirmPassword is required");
        }
        }
    }

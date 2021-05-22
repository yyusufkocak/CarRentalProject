using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDTOValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDTOValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).Must(PasswordStrong).WithMessage(Messages.PasswordNotStrongEnough);
        }

        private bool PasswordStrong(string password)
        {
            return password.Any(char.IsDigit)
                && password.Any(char.IsLetter)
                && password.Any(char.IsUpper)
                && password.Any(char.IsLower)
                && password.Any(char.IsSymbol);
        }
    }
}

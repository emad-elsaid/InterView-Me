using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Shared;

namespace Web.Validators.Shared
{
    public class LoginInfoValidator :AbstractValidator<LoginInfoModel>
    {
        public LoginInfoValidator()
        {
            RuleFor(l => l.Email).NotEmpty().WithMessage("Email Is Required");
            RuleFor(l => l.Email).EmailAddress().WithMessage("Invalid Email Format");
            RuleFor(l => l.Password).NotEmpty().WithMessage("Password Is Required");

        }
    }
}

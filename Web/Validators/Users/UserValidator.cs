using FluentValidation;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Users;

namespace Web.Validators.Users
{
    public class UserValidator :AbstractValidator<UserModel>
    {
        private readonly IUserService _UserService;
        public UserValidator(IUserService userService)
        {
            _UserService = userService;
            RuleFor(u => u.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(u => u.Email).NotEmpty().WithMessage(" Email is required");
            RuleFor(u => u.Password).NotEmpty().WithMessage(" Password is required");
            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required");
            // Custom check if email already Exist or not 
            RuleFor(u => u.Email).Custom((p,c) => {
            if (_UserService.GetByEmail(p) != null)
                    c.AddFailure("Email already Exist");
            });

        }
    }
}

using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validator
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDTO>
    {
        private ECommerceContext _context;
        public RegisterUserValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("First Name cannot be null.")
                .NotEmpty().WithMessage("First Name cannot be empty.")
                .MinimumLength(3).WithMessage("First Name cannot be shorter than 3 characters.");
            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Last Name cannot be null.")
                .NotEmpty().WithMessage("Last Name cannot be empty.")
                .MinimumLength(3).WithMessage("Last Name cannot be shorter than 3 characters.");
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotNull().WithMessage("Email cannot be null.")
                .NotEmpty().WithMessage("Email cannot be empty.")
                .MinimumLength(3).WithMessage("Email cannot be shorter than 3 characters.")
                .Must(EmailNotInUse).WithMessage("Email is already registered.");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password cannot be null.")
                .NotEmpty().WithMessage("Password cannot be empty.")
                .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$")
                .WithMessage("The password must have a minimum eight characters, at least one letter and one number.");
            //Minimum eight characters, at least one letter and one number
            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("Phone Number cannot be null.")
                .NotEmpty().WithMessage("Phone Number cannot be empty.")
                .Matches("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")
                .WithMessage("The phone number is formatted incorrectly.");
            //Matches the following
            //+919367788755
            //8989829304
            //+ 16308520397
            //786 - 307 - 3615
            RuleFor(x => x.UserAdress)
                .NotNull().WithMessage("User Address cannot be null.")
                .NotEmpty().WithMessage("User Address cannot be empty.")
                .MinimumLength(3).WithMessage("User Address cannot be shorter than 3 characters.");
        }

        private bool EmailNotInUse(string email)
        {
            var exists = _context.Users.Any(x => x.Email == email);
            return !exists;
        }
    }
}

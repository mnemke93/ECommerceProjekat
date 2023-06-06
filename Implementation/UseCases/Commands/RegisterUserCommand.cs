using Application;
using Application.UseCases.Commands;
using Application.UseCases.DTO;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands
{
    public class RegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private RegisterUserValidator _validator;
        public RegisterUserCommand(ECommerceContext context, RegisterUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 6;

        public string Name => "Register User";

        public string Description => "Register User Using Entity Framework.";

        public void Execute(RegisterUserDTO request)
        {
            _validator.ValidateAndThrow(request);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = hashedPassword,
                PhoneNumber = request.PhoneNumber,
                UserAdress = request.UserAdress,
                IsAdmin = false
            };

            Context.Users.Add(user);

            Context.SaveChanges();
        }
    }
}

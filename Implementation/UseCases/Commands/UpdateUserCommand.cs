using Application.UseCases.Commands;
using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands
{
    public class UpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private UpdateUserValidator _validator;
        public UpdateUserCommand(ECommerceContext context, UpdateUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 9;

        public string Name =>"Update User";

        public string Description => "Update User Using EF Framework.";

        public void Execute(UpdateUserDTO request)
        {
            _validator.ValidateAndThrow(request);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var userToUpdate = Context.Users.Where(x => x.ID == request.ID).First();
            userToUpdate.FirstName = request.FirstName;
            userToUpdate.LastName = request.LastName;
            userToUpdate.Email = request.Email;
            userToUpdate.Password = hashedPassword;
            userToUpdate.PhoneNumber = request.PhoneNumber;
            userToUpdate.UserAdress = request.UserAdress;
            userToUpdate.IsAdmin = request.IsAdmin;
            userToUpdate.UpdatedAt = DateTime.Now;
            userToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

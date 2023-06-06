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
    public class DeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        private DeleteUserValidator _validator;
        public DeleteUserCommand(ECommerceContext context, DeleteUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 9;

        public string Name => "Delete User";

        public string Description => "Delete User Using EF Framework.";

        public void Execute(DeleteUserDTO request)
        {
            _validator.ValidateAndThrow(request);

            var userToDelete = Context.Users.Where(x => x.ID == request.ID).First();
            Context.Users.Remove(userToDelete);

            Context.SaveChanges();
        }
    }
}

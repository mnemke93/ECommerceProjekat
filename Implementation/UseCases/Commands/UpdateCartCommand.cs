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
    public class UpdateCartCommand : EfUseCase, IUpdateCartCommand
    {
        private UpdateCartValidator _validator;
        public UpdateCartCommand(ECommerceContext context, UpdateCartValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 14;

        public string Name => "Update Cart";

        public string Description => "Update Cart Using EF Framework.";

        public void Execute(UpdateCartDTO request)
        {
            _validator.ValidateAndThrow(request);

            var cartToUpdate = Context.Carts.Where(x => x.ID == request.ID).First();
            cartToUpdate.UserID = request.UserID;
            cartToUpdate.UpdatedAt = DateTime.Now;
            cartToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

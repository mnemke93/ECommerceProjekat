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
    public class UpdateCartItemCommand : EfUseCase, IUpdateCartItemCommand
    {
        private UpdateCartItemValidator _validator;
        public UpdateCartItemCommand(ECommerceContext context, UpdateCartItemValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 17;

        public string Name => "Update Cart Item";

        public string Description => "Update Cart Item Using EF Framework.";

        public void Execute(UpdateCartItemDTO request)
        {
            _validator.ValidateAndThrow(request);

            var cartItemToUpdate = Context.CartItems.Where(x => x.ID == request.ID).First();
            cartItemToUpdate.Quantity = request.Quantity;
            cartItemToUpdate.CartID = request.CartID;
            cartItemToUpdate.ProductID = request.ProductID;
            cartItemToUpdate.UpdatedAt = DateTime.Now;
            cartItemToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

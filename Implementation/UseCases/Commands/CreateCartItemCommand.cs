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
    public class CreateCartItemCommand : EfUseCase, ICreateCartItemCommand
    {
        private CreateCartItemValidator _validator;
        public CreateCartItemCommand(ECommerceContext context, CreateCartItemValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 16;

        public string Name => "Create Cart Item";

        public string Description => "Create Cart Item Using EF Framework.";

        public void Execute(CreateCartItemDTO request)
        {
            _validator.ValidateAndThrow(request);

            var cartItem = new CartItem
            {
                Quantity = request.Quantity,
                CartID = request.CartID,
                ProductID = request.ProductID,
            };

            Context.CartItems.Add(cartItem);

            Context.SaveChanges();
        }
    }
}

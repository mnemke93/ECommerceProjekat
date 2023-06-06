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
    public class DeleteCartItemCommand : EfUseCase, IDeleteCartItemCommand
    {
        private DeleteCartItemValidator _validator;
        public DeleteCartItemCommand(ECommerceContext context, DeleteCartItemValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 18;

        public string Name => "Delete Cart Item";

        public string Description => "Delete Cart Item Using EF Framework.";

        public void Execute(DeleteCartItemDTO request)
        {
            _validator.ValidateAndThrow(request);

            var cartItemToDelete = Context.CartItems.Where(x => x.ID == request.ID).First();
            Context.CartItems.Remove(cartItemToDelete);

            Context.SaveChanges();
        }
    }
}

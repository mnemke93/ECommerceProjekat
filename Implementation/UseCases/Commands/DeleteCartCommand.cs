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
    public class DeleteCartCommand : EfUseCase, IDeleteCartCommand
    {
        private DeleteCartValidator _validator;
        public DeleteCartCommand(ECommerceContext context, DeleteCartValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 15;

        public string Name => "Delete Cart";

        public string Description => "Delete Cart Using EF Framework.";

        public void Execute(DeleteCartDTO request)
        {
            _validator.ValidateAndThrow(request);

            var cartToDelete = Context.Carts.Where(x => x.ID == request.ID).First();
            Context.Carts.Remove(cartToDelete);

            Context.SaveChanges();
        }
    }
}

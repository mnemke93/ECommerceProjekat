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
    public class DeleteProductCommand : EfUseCase, IDeleteProductCommand
    {
        private DeleteProductValidator _validator;
        public DeleteProductCommand(ECommerceContext context, DeleteProductValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 33;

        public string Name => "Delete Product";

        public string Description => "Delete Product Using EF Framework.";

        public void Execute(DeleteProductDTO request)
        {
            _validator.ValidateAndThrow(request);

            var productToDelete = Context.Products.Where(x => x.ID == request.ID).First();
            Context.Products.Remove(productToDelete);

            Context.SaveChanges();
        }
    }
}

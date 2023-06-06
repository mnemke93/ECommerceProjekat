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
    public class UpdateProductCommand : EfUseCase, IUpdateProductCommand
    {
        private UpdateProductValidator _validator;
        public UpdateProductCommand(ECommerceContext context, UpdateProductValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 32;

        public string Name => "Update Product";

        public string Description => "Update Product Using EF Framework.";

        public void Execute(UpdateProductDTO request)
        {
            _validator.ValidateAndThrow(request);

            var productToUpdate = Context.Products.Where(x => x.ID == request.ID).First();
            productToUpdate.ProductName = request.ProductName;
            productToUpdate.ProductDescription = request.ProductDescription;
            productToUpdate.Price = request.Price;
            productToUpdate.Quantity = request.Quantity;
            productToUpdate.CategoryID = request.CategoryID;
            productToUpdate.SupplierID = request.SupplierID;
            productToUpdate.UpdatedAt = DateTime.Now;
            productToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

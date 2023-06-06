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
    public class CreateProductCommand : EfUseCase, ICreateProductCommand
    {
        private CreateProductValidator _validator;
        public CreateProductCommand(ECommerceContext context, CreateProductValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 31;

        public string Name => "Create Product";

        public string Description => "Create Product Using EF Framework.";

        public void Execute(CreateProductDTO request)
        {
            _validator.ValidateAndThrow(request);

            var product = new Product
            {
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                Price = request.Price,
                Quantity = request.Quantity,
                CategoryID = request.CategoryID,
                SupplierID = request.SupplierID,
            };

            Context.Products.Add(product);

            Context.SaveChanges();
        }
    }
}

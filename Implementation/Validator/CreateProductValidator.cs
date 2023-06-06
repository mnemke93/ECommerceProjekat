using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validator
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        private ECommerceContext _context;
        public CreateProductValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ProductName)
                .NotNull().WithMessage("Product Name cannot be null.")
                .NotEmpty().WithMessage("Product Name cannot be empty.");
            RuleFor(x => x.ProductDescription)
                .NotNull().WithMessage("Product Description cannot be null.")
                .NotEmpty().WithMessage("Product Description cannot be empty.");
            RuleFor(x => x.Price).NotNull().WithMessage("Price cannot be null.");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Price cannot be null.");
            RuleFor(x => x.CategoryID).NotNull().WithMessage("Category ID cannot be null.");
            RuleFor(x => x.SupplierID).NotNull().WithMessage("Supplier ID cannot be null.");
        }
    }
}

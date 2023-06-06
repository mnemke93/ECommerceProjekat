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
    public class CreateCartItemValidator : AbstractValidator<CreateCartItemDTO>
    {
        private ECommerceContext _context;
        public CreateCartItemValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ProductID).NotNull().WithMessage("Product ID cannot be null.");
            RuleFor(x => x.CartID).NotNull().WithMessage("Cart ID cannot be null.");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity cannot be null.");
        }
    }
}

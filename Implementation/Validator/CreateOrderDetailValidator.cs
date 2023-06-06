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
    public class CreateOrderDetailValidator : AbstractValidator<CreateOrderDetailDTO>
    {
        private ECommerceContext _context;
        public CreateOrderDetailValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity cannot be null.");
            RuleFor(x => x.Price).NotNull().WithMessage("Price cannot be null.");
            RuleFor(x => x.OrderId).NotNull().WithMessage("Order ID cannot be null.");
            RuleFor(x => x.ProductId).NotNull().WithMessage("Product ID cannot be null.");
        }
    }
}

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
    public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
    {
        private ECommerceContext _context;
        public CreateOrderValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.OrderDate).NotNull().WithMessage("Order Date cannot be null.");
            RuleFor(x => x.OrderStatus).NotNull().WithMessage("Order Status cannot be null.");
            RuleFor(x => x.UserID).NotNull().WithMessage("User ID cannot be null.");
            RuleFor(x => x.PaymentID).NotNull().WithMessage("Payment ID cannot be null.");
        }
    }
}

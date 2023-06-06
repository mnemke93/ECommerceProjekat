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
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDTO>
    {
        private ECommerceContext _context;
        public UpdateOrderValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID).NotNull().WithMessage("ID cannot be null.");
            RuleFor(x => x.OrderDate).NotNull().WithMessage("Order Date cannot be null.");
            RuleFor(x => x.OrderStatus).NotNull().WithMessage("Order Status cannot be null.");
            RuleFor(x => x.UserID).NotNull().WithMessage("User ID cannot be null.");
            RuleFor(x => x.PaymentID).NotNull().WithMessage("Payment ID cannot be null.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive cannot be null.");
        }
    }
}

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
    public class UpdateOrderDetailValidator : AbstractValidator<UpdateOrderDetailDTO>
    {
        private ECommerceContext _context;
        public UpdateOrderDetailValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID).NotNull().WithMessage("ID cannot be null.");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity cannot be null.");
            RuleFor(x => x.Price).NotNull().WithMessage("Price cannot be null.");
            RuleFor(x => x.OrderId).NotNull().WithMessage("Order ID cannot be null.");
            RuleFor(x => x.ProductId).NotNull().WithMessage("Product ID cannot be null.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive cannot be null.");
        }
    }
}

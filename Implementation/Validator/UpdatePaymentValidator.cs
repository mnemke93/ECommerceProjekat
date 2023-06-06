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
    public class UpdatePaymentValidator : AbstractValidator<UpdatePaymentDTO>
    {
        private ECommerceContext _context;
        public UpdatePaymentValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID).NotNull().WithMessage("ID cannot be null.");
            RuleFor(x => x.PaymentMethod).NotNull().WithMessage("Payment Method cannot be null.");
            RuleFor(x => x.PaymentStatus).NotNull().WithMessage("Payment Status cannot be null.");
            RuleFor(x => x.TransactionID).NotNull().WithMessage("Transaction ID cannot be null.");
            RuleFor(x => x.PaymentDate).NotNull().WithMessage("Payment Date cannot be null.");
            RuleFor(x => x.OrderID).NotNull().WithMessage("Order ID cannot be null.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive cannot be null.");
        }
    }
}

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
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewDTO>
    {
        private ECommerceContext _context;
        public UpdateReviewValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID).NotNull().WithMessage("ID cannot be null.");
            RuleFor(x => x.Rating).NotNull().WithMessage("Rating cannot be null.");
            RuleFor(x => x.Body).NotNull().WithMessage("Body cannot be null.")
                .NotEmpty().WithMessage("Body cannot be empty.");
            RuleFor(x => x.UserID).NotNull().WithMessage("User ID cannot be null.");
            RuleFor(x => x.ProductID).NotNull().WithMessage("Product ID cannot be null.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive cannot be null.");
        }
    }
}

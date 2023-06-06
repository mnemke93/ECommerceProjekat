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
    public class CreateReviewValidator :AbstractValidator<CreateReviewDTO>
    {
        private ECommerceContext _context;
        public CreateReviewValidator(ECommerceContext context) 
        {
            _context = context;
            RuleFor(x => x.Rating).NotNull().WithMessage("Rating cannot be null.");
            RuleFor(x => x.Body).NotNull().WithMessage("Body cannot be null.")
                .NotEmpty().WithMessage("Body cannot be empty.");
            RuleFor(x => x.UserID).NotNull().WithMessage("User ID cannot be null.");
            RuleFor(x => x.ProductID).NotNull().WithMessage("Product ID cannot be null.");
        }
    }
}

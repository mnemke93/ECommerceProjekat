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
    public class UpdateImageValidator : AbstractValidator<UpdateImageDTO>
    {
        private ECommerceContext _context;
        public UpdateImageValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID).NotNull().WithMessage("ID cannot be null.");
            RuleFor(x => x.ImageUrl)
                .NotNull().WithMessage("Quantity cannot be null.")
                .NotEmpty().WithMessage("Quantity cannot be empty.");
            RuleFor(x => x.IsPrimary).NotNull().WithMessage("IsPrimary cannot be null.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive cannot be null.");
        }
    }
}

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
    public class DeleteCartItemValidator : AbstractValidator<DeleteCartItemDTO>
    {
        private ECommerceContext _context;
        public DeleteCartItemValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID).NotNull().WithMessage("Product ID cannot be null.");
        }
    }
}

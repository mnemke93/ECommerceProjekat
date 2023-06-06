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
    public class CreateCartValidator : AbstractValidator<CreateCartDTO>
    {
        private ECommerceContext _context;
        public CreateCartValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.UserID).NotNull().WithMessage("User ID cannot be null.");
        }
    }
}

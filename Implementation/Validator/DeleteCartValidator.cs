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
    public class DeleteCartValidator : AbstractValidator<DeleteCartDTO>
    {
        private ECommerceContext _context;
        public DeleteCartValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID).NotNull().WithMessage("User ID cannot be null.");
        }
    }
}

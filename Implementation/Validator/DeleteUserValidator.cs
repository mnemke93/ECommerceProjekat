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
    public class DeleteUserValidator : AbstractValidator<DeleteUserDTO>
    {
        private ECommerceContext _context;
        public DeleteUserValidator(ECommerceContext context) 
        {
            _context = context;
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID cannot be null.");
        }
    }
}

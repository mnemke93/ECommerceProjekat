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
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierDTO>
    {
        private ECommerceContext _context;
        public UpdateSupplierValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID cannot be null.");
            RuleFor(x => x.SupplierName)
                .NotNull().WithMessage("Supplier Name cannot be null.")
                .NotEmpty().WithMessage("Supplier Name cannot be empty.")
                .MinimumLength(3).WithMessage("Supplier Name cannot be shorter than 3 characters.");
            RuleFor(x => x.SupplierContact)
                .NotNull().WithMessage("Supplier Contact cannot be null.")
                .NotEmpty().WithMessage("Supplier Contact cannot be empty.")
                .MinimumLength(3).WithMessage("Supplier Contact cannot be shorter than 3 characters.");
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Is Active cannot be null.");

        }
    }
}

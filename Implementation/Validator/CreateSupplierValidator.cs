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
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierDTO>
    {
        private ECommerceContext _context;
        public CreateSupplierValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.SupplierName)
                .NotNull().WithMessage("Supplier Name cannot be null.")
                .NotEmpty().WithMessage("Supplier Name cannot be empty.")
                .MinimumLength(3).WithMessage("Supplier Name cannot be shorter than 3 characters.")
                .Must(SupplierNotInUse).WithMessage("Supplier already exists in database.");
            RuleFor(x => x.SupplierContact)
                .NotNull().WithMessage("Category Contact cannot be null.")
                .NotEmpty().WithMessage("Category Contact cannot be empty.")
                .MinimumLength(3).WithMessage("Category Contact cannot be shorter than 3 characters.");


        }

        private bool SupplierNotInUse(string name)
        {
            var exists = _context.Suppliers.Any(x => x.SupplierName == name);
            return !exists;
        }
    }
}

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
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {
        private ECommerceContext _context;
        public UpdateCategoryValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID cannot be null.");
            RuleFor(x => x.CategoryName)
                .NotNull().WithMessage("Category Name cannot be null.")
                .NotEmpty().WithMessage("Category Name cannot be empty.")
                .MinimumLength(3).WithMessage("Category Name cannot be shorter than 3 characters.");
            RuleFor(x => x.CategoryDescription)
                .NotNull().WithMessage("Category Description cannot be null.")
                .NotEmpty().WithMessage("Category Description cannot be empty.")
                .MinimumLength(3).WithMessage("Category Description cannot be shorter than 3 characters.");
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Is Active cannot be null.");

        }

        
    }
}

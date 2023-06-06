using Application.DTO;
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
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        private ECommerceContext _context;
        public CreateCategoryValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.CategoryName)
                .NotNull().WithMessage("Category Name cannot be null.")
                .NotEmpty().WithMessage("Category Name cannot be empty.")
                .MinimumLength(3).WithMessage("Category Name cannot be shorter than 3 characters.")
                .Must(CategoryNotInUse).WithMessage("Category already exists in database.");
            RuleFor(x => x.CategoryDescription)
                .NotNull().WithMessage("Category Description cannot be null.")
                .NotEmpty().WithMessage("Category Description cannot be empty.")
                .MinimumLength(3).WithMessage("Category Description cannot be shorter than 3 characters.");


        }

        private bool CategoryNotInUse(string name)
        {
            var exists = _context.Categories.Any(x => x.CategoryName == name);
            return !exists;
        }
    }
}

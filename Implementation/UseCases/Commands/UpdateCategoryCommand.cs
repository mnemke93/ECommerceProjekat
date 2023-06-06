using Application.UseCases.Commands;
using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands
{
    public class UpdateCategoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        public UpdateCategoryValidator _validator { get; set; }
        public UpdateCategoryCommand(ECommerceContext context, UpdateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 4;

        public string Name => "Update Category";

        public string Description => "Update Category Using Entity Framework";

        public void Execute(UpdateCategoryDTO request)
        {
            _validator.ValidateAndThrow(request);

            var categoryToUpdate = Context.Categories.Where(x => x.ID == request.ID).First();
            categoryToUpdate.CategoryName = request.CategoryName;
            categoryToUpdate.CategoryDescription = request.CategoryDescription;
            categoryToUpdate.UpdatedAt = DateTime.Now;
            categoryToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

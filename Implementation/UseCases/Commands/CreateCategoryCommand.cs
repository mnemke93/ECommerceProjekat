using Application.UseCases.Commands;
using Application.UseCases.DTO;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands
{
    public class CreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        public CreateCategoryValidator _validator { get; set; }
        public CreateCategoryCommand(ECommerceContext context, CreateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int ID => 3;

        public string Name => "Create Category";

        public string Description => "Create Category Using Entity Framework.";

        public void Execute(CreateCategoryDTO request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
            };

            Context.Categories.Add(category);

            Context.SaveChanges();
        }
    }
}

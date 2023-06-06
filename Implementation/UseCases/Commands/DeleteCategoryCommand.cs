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
    public class DeleteCategoryCommand : EfUseCase, IDeleteCategoryCommand
    {
        public DeleteCategoryValidator _validator { get; set; }
        public DeleteCategoryCommand(ECommerceContext context, DeleteCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 5;

        public string Name => "Delete Category";

        public string Description => "Delete Category Using Entity Framework.";

        public void Execute(DeleteCategoryDTO request)
        {
            _validator.ValidateAndThrow(request);

            var categoryToDelete = Context.Categories.Where(x => x.ID == request.ID).First();
            Context.Categories.Remove(categoryToDelete);

            Context.SaveChanges();
        }
    }
}

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
    public class DeleteImageCommand : EfUseCase, IDeleteImageCommand
    {
        private DeleteImageValidator _validator;
        public DeleteImageCommand(ECommerceContext context, DeleteImageValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 27;

        public string Name => "Delete Image";

        public string Description => "Delete Image Using EF Framework.";

        public void Execute(DeleteImageDTO request)
        {
            _validator.ValidateAndThrow(request);

            var imageToDelete = Context.Images.Where(x => x.ID == request.ID).First();
            Context.Images.Remove(imageToDelete);

            Context.SaveChanges();
        }
    }
}

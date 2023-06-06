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
    public class UpdateImageCommand : EfUseCase, IUpdateImageCommand
    {
        private UpdateImageValidator _validator;
        public UpdateImageCommand(ECommerceContext context, UpdateImageValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 26;

        public string Name => "Update Image";

        public string Description => "Update Image Using EF Framework.";

        public void Execute(UpdateImageDTO request)
        {
            _validator.ValidateAndThrow(request);

            var imageToUpdate = Context.Images.Where(x => x.ID == request.ID).First();
            imageToUpdate.ImageUrl = request.ImageUrl;
            imageToUpdate.IsPrimary = request.IsPrimary;
            imageToUpdate.UserID = request.UserID;
            imageToUpdate.ProductID = request.ProductID;
            imageToUpdate.UpdatedAt = DateTime.Now;
            imageToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

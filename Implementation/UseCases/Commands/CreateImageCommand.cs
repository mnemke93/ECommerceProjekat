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
    public class CreateImageCommand : EfUseCase, ICreateImageCommand
    {
        private CreateImageValidator _validator;
        public CreateImageCommand(ECommerceContext context, CreateImageValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 25;

        public string Name => "Create Image";

        public string Description => "Create Image Using EF Framework.";

        public void Execute(CreateImageDTO request)
        {
            _validator.ValidateAndThrow(request);

            var image = new Image
            {
                ImageUrl = request.ImageUrl,
                IsPrimary = request.IsPrimary,
                UserID = request.UserID,
                ProductID = request.ProductID,
            };

            Context.Images.Add(image);

            Context.SaveChanges();
        }
    }
}

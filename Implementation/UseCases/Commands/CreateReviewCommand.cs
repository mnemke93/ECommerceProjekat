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
    public class CreateReviewCommand : EfUseCase, ICreateReviewCommand
    {
        private CreateReviewValidator _validator;
        public CreateReviewCommand(ECommerceContext context, CreateReviewValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 10;

        public string Name => "Create Review";

        public string Description => "Create Review Using EF Framework.";

        public void Execute(CreateReviewDTO request)
        {
            _validator.ValidateAndThrow(request);

            var review = new Review
            {
                Rating = request.Rating,
                Body = request.Body,
                UserID = request.UserID,
                ProductID = request.ProductID,
            };

            Context.Reviews.Add(review);

            Context.SaveChanges();
        }
    }
}

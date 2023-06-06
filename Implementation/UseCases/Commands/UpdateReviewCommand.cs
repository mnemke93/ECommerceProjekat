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
    public class UpdateReviewCommand : EfUseCase, IUpdateReviewCommand
    {
        private UpdateReviewValidator _validator;
        public UpdateReviewCommand(ECommerceContext context, UpdateReviewValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 11;

        public string Name => "Update Review";

        public string Description => "Update Review Using EF Framework.";

        public void Execute(UpdateReviewDTO request)
        {
            _validator.ValidateAndThrow(request);

            var reviewToUpdate = Context.Reviews.Where(x => x.ID == request.ID).First();
            reviewToUpdate.Rating = request.Rating;
            reviewToUpdate.Body = request.Body;
            reviewToUpdate.UserID = request.UserID;
            reviewToUpdate.ProductID = request.ProductID;
            reviewToUpdate.UpdatedAt = DateTime.Now;
            reviewToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

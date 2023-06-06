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
    public class DeleteReviewCommand : EfUseCase, IDeleteReviewCommand
    {
        private DeleteReviewValidator _validator;
        public DeleteReviewCommand(ECommerceContext context, DeleteReviewValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 12;

        public string Name => "Delete Review";

        public string Description => "Delete Review Using EF framework";

        public void Execute(DeleteReviewDTO request)
        {
            _validator.ValidateAndThrow(request);

            var reviewToDelete = Context.Reviews.Where(x => x.ID == request.ID).First();
            Context.Reviews.Remove(reviewToDelete);

            Context.SaveChanges();
        }
    }
}

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
    public class CreateCartCommand : EfUseCase, ICreateCartCommand
    {
        private CreateCartValidator _validator;
        public CreateCartCommand(ECommerceContext context, CreateCartValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 13;

        public string Name => "Create Cart";

        public string Description => "Create Cart Using EF Framework.";

        public void Execute(CreateCartDTO request)
        {
            _validator.ValidateAndThrow(request);

            var cart = new Cart
            {
                UserID = request.UserID,
            };

            Context.Carts.Add(cart);

            Context.SaveChanges();
        }
    }
}

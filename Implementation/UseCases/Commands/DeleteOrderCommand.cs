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
    public class DeleteOrderCommand : EfUseCase, IDeleteOrderCommand
    {
        private DeleteOrderValidator _validator;
        public DeleteOrderCommand(ECommerceContext context, DeleteOrderValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 21;

        public string Name => "Delete Order";

        public string Description => "Delete Order Using EF Framework.";

        public void Execute(DeleteOrderDTO request)
        {
            _validator.ValidateAndThrow(request);

            var orderToDelete = Context.Orders.Where(x => x.ID == request.ID).First();
            Context.Orders.Remove(orderToDelete);

            Context.SaveChanges();
        }
    }
}

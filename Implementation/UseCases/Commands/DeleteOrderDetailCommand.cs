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
    public class DeleteOrderDetailCommand : EfUseCase, IDeleteOrderDetailCommand
    {
        private DeleteOrderDetailValidator _validator;
        public DeleteOrderDetailCommand(ECommerceContext context, DeleteOrderDetailValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 24;

        public string Name => "Delete Order Detail";

        public string Description => "Delete Order Detail Using EF Framework.";

        public void Execute(DeleteOrderDetailDTO request)
        {
            _validator.ValidateAndThrow(request);

            var orderDetailToDelete = Context.OrderDetails.Where(x => x.ID == request.ID).First();
            Context.OrderDetails.Remove(orderDetailToDelete);

            Context.SaveChanges();
        }
    }
}

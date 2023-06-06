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
    public class UpdateOrderCommand : EfUseCase, IUpdateOrderCommand
    {
        private UpdateOrderValidator _validator;
        public UpdateOrderCommand(ECommerceContext context, UpdateOrderValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 20;

        public string Name => "Update Order";

        public string Description => "Update Order Using EF Framework.";

        public void Execute(UpdateOrderDTO request)
        {
            _validator.ValidateAndThrow(request);

            var orderToUpdate = Context.Orders.Where(x => x.ID == request.ID).First();
            orderToUpdate.OrderDate = request.OrderDate;
            orderToUpdate.OrderStatus = request.OrderStatus;
            orderToUpdate.UserID = request.UserID;
            orderToUpdate.PaymentID = request.PaymentID;
            orderToUpdate.UpdatedAt = DateTime.Now;
            orderToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

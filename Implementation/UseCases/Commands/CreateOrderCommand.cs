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
    public class CreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
        private CreateOrderValidator _validator;
        public CreateOrderCommand(ECommerceContext context, CreateOrderValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 19;

        public string Name => "Create Order";

        public string Description => "Create Order Using EF Framework.";

        public void Execute(CreateOrderDTO request)
        {
            _validator.ValidateAndThrow(request);

            var order = new Order
            {
                OrderDate = request.OrderDate,
                OrderStatus = request.OrderStatus,
                UserID = request.UserID,
                PaymentID = request.PaymentID,
            };

            Context.Orders.Add(order);

            Context.SaveChanges();
        }
    }
}

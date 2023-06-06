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
    public class CreateOrderDetailCommand : EfUseCase, ICreateOrderDetailCommand
    {
        private CreateOrderDetailValidator _validator;
        public CreateOrderDetailCommand(ECommerceContext context, CreateOrderDetailValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 22;

        public string Name => "Create Order Detail";

        public string Description => "Create Order Detail Using EF Framework.";

        public void Execute(CreateOrderDetailDTO request)
        {
            _validator.ValidateAndThrow(request);

            var orderDetail = new OrderDetail
            {
                Quantity = request.Quantity,
                Price = request.Price,
                OrderID = request.OrderId,
                ProductID = request.ProductId,
            };

            Context.OrderDetails.Add(orderDetail);

            Context.SaveChanges();
        }
    }
}

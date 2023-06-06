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
    public class UpdateOrderDetailCommand : EfUseCase, IUpdateOrderDetailCommand
    {
        private UpdateOrderDetailValidator _validator;
        public UpdateOrderDetailCommand(ECommerceContext context, UpdateOrderDetailValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 23;

        public string Name => "Update Order Detail";

        public string Description => "Update Order Detail Using EF Framework.";

        public void Execute(UpdateOrderDetailDTO request)
        {
            _validator.ValidateAndThrow(request);

            var orderDetailToUpdate = Context.OrderDetails.Where(x => x.ID == request.ID).First();
            orderDetailToUpdate.Quantity = request.Quantity;
            orderDetailToUpdate.Price = request.Price;
            orderDetailToUpdate.OrderID = request.OrderId;
            orderDetailToUpdate.ProductID = request.ProductId;
            orderDetailToUpdate.UpdatedAt = DateTime.Now;
            orderDetailToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

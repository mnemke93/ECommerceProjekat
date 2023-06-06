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
    public class UpdatePaymentCommand : EfUseCase, IUpdatePaymentCommand
    {
        private UpdatePaymentValidator _validator;
        public UpdatePaymentCommand(ECommerceContext context, UpdatePaymentValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 29;

        public string Name => "Update Payment";

        public string Description => "Update Payment Using EF Framework.";

        public void Execute(UpdatePaymentDTO request)
        {
            _validator.ValidateAndThrow(request);

            var paymentToUpdate = Context.Payments.Where(x => x.ID == request.ID).First();
            paymentToUpdate.PaymentMethod = request.PaymentMethod;
            paymentToUpdate.PaymentStatus = request.PaymentStatus;
            paymentToUpdate.PaymentDate = request.PaymentDate;
            paymentToUpdate.OrderID = request.OrderID;
            paymentToUpdate.UpdatedAt = DateTime.Now;
            paymentToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

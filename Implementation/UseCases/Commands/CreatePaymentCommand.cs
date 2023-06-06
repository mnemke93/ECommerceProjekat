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
    public class CreatePaymentCommand : EfUseCase, ICreatePaymentCommand
    {
        private CreatePaymentValidator _validator;
        public CreatePaymentCommand(ECommerceContext context, CreatePaymentValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 28;

        public string Name => "Create Payment";

        public string Description => "Create Payment Using EF Framework.";

        public void Execute(CreatePaymentDTO request)
        {
            _validator.ValidateAndThrow(request);

            var payment = new Payment
            {
                PaymentMethod = request.PaymentMethod,
                PaymentStatus = request.PaymentStatus,
                TransactionID = request.TransactionID,
                PaymentDate = request.PaymentDate,
                OrderID = request.OrderID
            };

            Context.Payments.Add(payment);

            Context.SaveChanges();
        }
    }
}

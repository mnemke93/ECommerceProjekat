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
    public class DeletePaymentCommand : EfUseCase, IDeletePaymentCommand
    {
        private DeletePaymentValidator _validator;
        public DeletePaymentCommand(ECommerceContext context, DeletePaymentValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 30;

        public string Name => "Delete Payment";

        public string Description => "Delete Payment Using EF Framework.";

        public void Execute(DeletePaymentDTO request)
        {
            _validator.ValidateAndThrow(request);

            var paymentToDelete = Context.Payments.Where(x => x.ID == request.ID).First();
            Context.Payments.Remove(paymentToDelete);

            Context.SaveChanges();
        }
    }
}

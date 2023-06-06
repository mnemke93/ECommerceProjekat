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
    public class DeleteSupplierCommand : EfUseCase, IDeleteSupplierCommand
    {
        private DeleteSupplierValidator _validator;
        public DeleteSupplierCommand(ECommerceContext context, DeleteSupplierValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 8;

        public string Name => "Delete Supplier";

        public string Description => "Delete Supplier Using Ef Framework";

        public void Execute(DeleteSupplierDTO request)
        {
            _validator.ValidateAndThrow(request);

            var supplierToDelete = Context.Suppliers.Where(x => x.ID == request.ID).First();
            Context.Suppliers.Remove(supplierToDelete);

            Context.SaveChanges();
        }
    }
}

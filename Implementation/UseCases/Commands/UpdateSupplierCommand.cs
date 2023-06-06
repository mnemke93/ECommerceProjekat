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
    public class UpdateSupplierCommand : EfUseCase, IUpdateSupplierCommand
    {
        public UpdateSupplierValidator _validator { get; set; }
        public UpdateSupplierCommand(ECommerceContext context, UpdateSupplierValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 4;

        public string Name => "Update Supplier";

        public string Description => "Update Supplier Using Entity Framework";

        public void Execute(UpdateSupplierDTO request)
        {
            _validator.ValidateAndThrow(request);

            var supplierToUpdate = Context.Suppliers.Where(x => x.ID == request.ID).First();
            supplierToUpdate.SupplierName = request.SupplierName;
            supplierToUpdate.SupplierContact = request.SupplierContact;
            supplierToUpdate.UpdatedAt = DateTime.Now;
            supplierToUpdate.IsActive = request.IsActive;

            Context.SaveChanges();
        }
    }
}

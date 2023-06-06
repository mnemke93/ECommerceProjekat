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
    public class CreateSupplierCommand : EfUseCase, ICreateSupplierCommand
    {
        public CreateSupplierValidator _validator { get; set; }
        public CreateSupplierCommand(ECommerceContext context, CreateSupplierValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int ID => 7;

        public string Name => "Create Suppplier";

        public string Description => "Create Supplier Using EF Framework";

        public void Execute(CreateSupplierDTO request)
        {
            _validator.ValidateAndThrow(request);

            var supplier = new Supplier
            {
                SupplierName = request.SupplierName,
                SupplierContact = request.SupplierContact,
            };

            Context.Suppliers.Add(supplier);

            Context.SaveChanges();
        }
    }
}

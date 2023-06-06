using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class SupplierDTO : BaseDTO
    {
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }
    }

    public class CreateSupplierDTO : BaseDTO
    {
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }
    }

    public class UpdateSupplierDTO : BaseDTO
    {
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteSupplierDTO : BaseDTO
    {
    }
}

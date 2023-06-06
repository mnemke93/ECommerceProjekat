using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class ProductDTO : BaseDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
    }

    public class CreateProductDTO : BaseDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
    }

    public class UpdateProductDTO : BaseDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public bool IsActive { get; set; }
    }
    public class DeleteProductDTO : BaseDTO
    {
    }
}

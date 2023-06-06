using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class OrderDetailDTO : BaseDTO
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }

    public class CreateOrderDetailDTO : BaseDTO
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
    public class UpdateOrderDetailDTO : BaseDTO
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteOrderDetailDTO : BaseDTO
    {
    }
}

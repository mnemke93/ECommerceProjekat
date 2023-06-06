using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class OrderDTO : BaseDTO
    {
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int UserID { get; set; }
        public int PaymentID { get; set; }
    }

    public class CreateOrderDTO : BaseDTO
    {
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int UserID { get; set; }
        public int PaymentID { get; set; }
    }

    public class UpdateOrderDTO : BaseDTO
    {
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int UserID { get; set; }
        public int PaymentID { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteOrderDTO : BaseDTO
    {
    }
}

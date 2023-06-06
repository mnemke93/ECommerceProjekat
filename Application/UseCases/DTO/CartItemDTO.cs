using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class CartItemDTO : BaseDTO
    {
        public int Quantity { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
    }

    public class CreateCartItemDTO : BaseDTO
    {
        public int Quantity { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
    }

    public class UpdateCartItemDTO : BaseDTO
    {
        public int Quantity { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteCartItemDTO : BaseDTO
    {
    }
}

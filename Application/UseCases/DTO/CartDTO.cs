using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class CartDTO : BaseDTO
    {
        public int UserID { get; set; }
    }

    public class CreateCartDTO : BaseDTO
    {
        public int UserID { get; set; }
    }

    public class UpdateCartDTO : BaseDTO
    {
        public int UserID { get; set; }
        public bool IsActive { get; set; }
    }
    public class DeleteCartDTO : BaseDTO
    {
    }

}

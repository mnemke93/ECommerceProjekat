using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail : Entity
    {
        //Data
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //Foreign Keys
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        //References
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

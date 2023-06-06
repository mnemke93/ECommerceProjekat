using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem : Entity
    {
        //Data
        public int Quantity { get; set; }

        //Foreign Keys
        public int CartID { get; set; }
        public int ProductID { get; set; }

        //References
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}

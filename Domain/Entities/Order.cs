using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : Entity
    {
        //Data
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        //Foreign Keys
        public int UserID { get; set; }
        public int PaymentID { get; set; }

        //References
        public virtual User User { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment : Entity
    {
        //Data
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string TransactionID { get; set; }
        public string PaymentDate { get; set; }

        //Foreign Keys
        public int OrderID { get; set; }

        //References
        public virtual Order Order { get; set; }
    }
}

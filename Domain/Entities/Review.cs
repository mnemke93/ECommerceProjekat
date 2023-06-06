using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review : Entity
    {
        //Data
        public int Rating { get; set; }
        public string Body { get; set; }

        //Foreign Keys
        public int UserID { get; set; }
        public int ProductID { get; set; }

        //References
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}

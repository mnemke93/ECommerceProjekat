using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image : Entity
    {
        //Data
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }

        //ForeignKeys
        public int? UserID { get; set; }
        public int? ProductID { get; set; }

        //References
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Supplier : Entity
    {
        //Data
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }

        //References
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}

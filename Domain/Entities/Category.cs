using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : Entity
    {
        //Data
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        //References
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}



using System.Collections.Generic;

namespace Riodetask.Model.Entity
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}

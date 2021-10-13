using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Model.Entity
{
    public class ProductImage : BaseEntity
    {
        public string Name { get; set; }
        public bool isMain { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Model.Entity
{
    public class Product : BaseEntity
    {
        public string StockKeepingUnit { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public string ShortDescription { get; set; }
        
        public virtual ICollection<ProductImage> Images { get; set; }



    }
}

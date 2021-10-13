using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Model.Entity
{
    public class Category :BaseEntity
    {
        public int? ParentID { get; set; }
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; set; }

        public string Name { get; set; }
        [Required]
        public string Description { get; set; }


    }
}

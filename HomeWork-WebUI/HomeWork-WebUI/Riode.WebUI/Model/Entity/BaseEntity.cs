using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Model.Entity
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int? DeleteByUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}

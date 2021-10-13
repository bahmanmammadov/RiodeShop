using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Model.Entity
{
    public class Faq : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }

    }
}

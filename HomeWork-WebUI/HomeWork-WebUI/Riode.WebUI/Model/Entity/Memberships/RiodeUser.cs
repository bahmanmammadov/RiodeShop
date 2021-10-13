using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Model.Memberships
{
    public class RiodeUser : IdentityUser<int>
    {
        public string FullName { get; set; }
       
    }
}

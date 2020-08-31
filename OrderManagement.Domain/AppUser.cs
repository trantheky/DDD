using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain
{
    public class AppUser: IdentityUser
    {
        public string DisplayName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

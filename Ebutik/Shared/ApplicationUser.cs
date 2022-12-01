using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcom.Shared
{
    public class ApplicationUser : IdentityUser
    {
        public string? CustomerName { get; set; }
        public string? Adress { get; set; }
        
    }
}

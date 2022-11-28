using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BlazorEcom.Shared
{
    public class RegisterModel : LoginModel
    {
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
        public string? CustomerName { get; set; }
        public string? Adress { get; set; }
    }
}

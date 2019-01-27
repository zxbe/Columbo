using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Sts.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        public string ReturnUrl { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

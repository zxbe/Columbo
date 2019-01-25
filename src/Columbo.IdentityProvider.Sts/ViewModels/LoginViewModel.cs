using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Sts.ViewModels
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}

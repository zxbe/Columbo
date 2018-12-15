using Columbo.Shared.Kernel.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Commands
{
    public class AddUserIdentityCommand : ICommand
    {
        public string Login { get; set; }
        public int PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public int CreatorId { get; set; }
        public List<int> RolesId { get; set; }

        public AddUserIdentityCommand()
        {
            RolesId = new List<int>();
        }
    }
}

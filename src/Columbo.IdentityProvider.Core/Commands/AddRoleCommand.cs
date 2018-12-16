using Columbo.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Commands
{
    public class AddRoleCommand : ICommand
    {
        public string Name { get; set; }
        public int InstanceId { get; set; }
        public int RoleTypeId { get; set; }
        public int CreatorId { get; set; }
        public List<int> PermissionsId { get; set; }

        public AddRoleCommand()
        {
            PermissionsId = new List<int>();
        }
    }
}

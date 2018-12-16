using Columbo.IdentityProvider.Core.Commands;
using Columbo.IdentityProvider.Core.Domain;
using Columbo.IdentityProvider.Core.Repositories;
using Columbo.Shared.Api.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Columbo.IdentityProvider.Service.CommandHandlers
{
    public class AddRoleCommandHandler : ICommandHandler<AddRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public AddRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void Handle(AddRoleCommand command)
        {
            var role = new Role(command.CreatorId, command.Name, command.InstanceId, command.RoleTypeId);
            role.AddPermissions(command.PermissionsId, command.CreatorId);

            _roleRepository.Add(role);
        }
    }
}
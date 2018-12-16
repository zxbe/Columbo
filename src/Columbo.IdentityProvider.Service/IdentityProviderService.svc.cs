using Columbo.IdentityProvider.Core.Commands;
using Columbo.IdentityProvider.Service.Dtos;
using Columbo.IdentityProvider.Service.ServiceContracts;
using Columbo.Shared.Api.Command;
using Columbo.Shared.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Columbo.IdentityProvider.Service
{
    public class IdentityProviderService : IIdentityProviderService
    {
        private readonly ICommandBus _commandBus;

        public IdentityProviderService(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public ServiceResult AddUserIdentity(UserIdentityDto UserIdentity)
        {
            try
            {
                var command = new AddUserIdentityCommand()
                {
                    Login = UserIdentity.Login,
                    PasswordHash = UserIdentity.PasswordHash.Value,
                    Name = UserIdentity.User.Name,
                    Surname = UserIdentity.User.Surname,
                    EmailAddress = UserIdentity.User.EmailAddress,
                    RolesId = UserIdentity.Roles.Select(x => x.Id).ToList(),
                    CreatorId = UserIdentity.CreatorId
                };

                _commandBus.Send(command);

                return ServiceResult.Ok();
            }
            catch (Exception e)
            {
                return ServiceResult.Fault(e);
            }
        }

        public ServiceResult AddRole(RoleDto Role)
        {
            try
            {
                var command = new AddRoleCommand()
                {
                    Name = Role.Name,
                    RoleTypeId = (int)Role.RoleType,
                    InstanceId = Role.InstanceId,
                    PermissionsId = Role.Permissions.Select(x => (int)x).ToList(),
                    CreatorId = Role.CreatorId
                };

                _commandBus.Send(command);

                return ServiceResult.Ok();
            }
            catch (Exception e)
            {
                return ServiceResult.Fault(e);
            }
        }

        public void TokenTest()
        {
            throw new NotImplementedException();
        }
    }
}

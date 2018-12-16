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
    public class AddUserIdentityCommandHandler : ICommandHandler<AddUserIdentityCommand>
    {
        private readonly IUserIdentityRepository _userIdentityRepository;

        public AddUserIdentityCommandHandler(IUserIdentityRepository userIdentityRepository)
        {
            _userIdentityRepository = userIdentityRepository;
        }

        public void Handle(AddUserIdentityCommand command)
        {
            var user = new User(command.CreatorId, command.Name, command.Surname, command.EmailAddress);
            var userIdentity = new UserIdentity(command.CreatorId, user, command.Login, command.PasswordHash);
            userIdentity.AddRoles(command.RolesId, command.CreatorId);

            _userIdentityRepository.Add(userIdentity);
        }
    }
}
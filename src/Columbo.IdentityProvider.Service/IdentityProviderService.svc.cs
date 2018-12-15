using Columbo.IdentityProvider.Service.Dtos;
using Columbo.IdentityProvider.Service.ServiceContracts;
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
        public ServiceResult AddUserIdentity(UserIdentityDto UserIdentity)
        {
            throw new NotImplementedException();
        }

        public void TokenTest()
        {
            throw new NotImplementedException();
        }

        public ServiceResult AddRole(RoleDto Role)
        {
            throw new NotImplementedException();
        }
    }
}

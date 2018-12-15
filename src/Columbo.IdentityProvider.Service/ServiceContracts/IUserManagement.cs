using Columbo.IdentityProvider.Service.Dtos;
using Columbo.Shared.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Service.ServiceContracts
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IUserManagement
    {
        [OperationContract]
        ServiceResult AddUserIdentity(UserIdentityDto UserIdentity);

        [OperationContract]
        ServiceResult AddRole(RoleDto Role);
    }
}

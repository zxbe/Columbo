using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Service.ServiceContracts
{
    [ServiceContract]
    public interface IIdentityProviderService : ISecurityTokenService, IUserManagementService
    {
    }
}

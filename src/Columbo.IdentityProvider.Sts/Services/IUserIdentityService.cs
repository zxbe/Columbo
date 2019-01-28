using Columbo.IdentityProvider.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Sts.Services
{
    public interface IUserIdentityService
    {
        UserIdentityDto GetUserIdentity(int id);
        bool IsUserIdentityActive(int id);
    }
}

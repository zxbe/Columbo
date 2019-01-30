using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Columbo.IdentityProvider.Api.Dtos;
using Columbo.IdentityProvider.Infrastructure.StoredProcedures;
using Columbo.Shared.Api.Security.Helpers;
using Columbo.Shared.Infrastructure;
using Columbo.Shared.Infrastructure.SqlTypes;
using Dapper;
using IdentityServer4.Models;
using static Columbo.Shared.Infrastructure.Helpers.DynamicParameterHelper;

namespace Columbo.IdentityProvider.Sts.Services
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public UserIdentityService(IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        public UserIdentityDto GetUserIdentity(int id)
        {
            var userIdentityIdParameter = AsParameter(id, "userIdentityId");
            var userIdentity = _storedProcedureExecutor.Execute<UserIdentityDto, UserDto>(userIdentityIdParameter, (ui, u) =>
            {
                ui.User = u;
                return ui;
            }, UserStoredProcedureEnum.GetUserIdentityById).FirstOrDefault();

            if (userIdentity == null)
                throw new Exception(); //todo exception

            var roles = _storedProcedureExecutor.Execute<RoleDto>(userIdentityIdParameter, UserStoredProcedureEnum.GetUserIdentityRoles).ToList();

            var rolesIdParameter = new IntList(roles.Select(x => x.Id).ToList()).AsTableValuedParameter("rolesId");
            var permissions = _storedProcedureExecutor.Execute<RolePermissionDto>(rolesIdParameter, UserStoredProcedureEnum.GetPermissionsByRolesId);

            roles.ForEach(x => x.Permissions = permissions.Where(y => y.RoleId == x.Id).Select(y => y.Permission).ToList());

            userIdentity.Roles = roles;

            return userIdentity;
        }

        public bool IsUserIdentityActive(int id)
        {
            var userIdentityIdParameter = AsParameter(id, "userIdentityId");
            return _storedProcedureExecutor.ExecuteSingleOrDefault<bool>(userIdentityIdParameter, UserStoredProcedureEnum.IsUserIdentityActive);            
        }

        public int? VerifyUserIdentity(string login, string password)
        {
            var passwordHash = password.Sha256();

            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(new { login = login, passwordHash = passwordHash });

            return _storedProcedureExecutor.ExecuteSingleOrDefault<int?>(parameters, UserStoredProcedureEnum.VerifyUserIdentity);
        }
    }
}

using Columbo.IdentityProvider.Api.Dtos;
using Columbo.IdentityProvider.Infrastructure.StoredProcedures;
using Columbo.Shared.Api.Security;
using Columbo.Shared.Api.Security.Enums;
using Columbo.Shared.Api.Security.Helpers;
using Columbo.Shared.Infrastructure;
using Columbo.Shared.Infrastructure.SqlTypes;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Columbo.Shared.Infrastructure.Helpers.DynamicParameterHelper;

namespace Columbo.IdentityProvider.Sts.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public ProfileService(IStoredProcedureExecutor storedProcedureExecutor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        private UserIdentityDto GetUserIdentity(int userIdentityId) // todo move to UserIdentityService
        {
            var userIdentityIdParameter = AsParameter(userIdentityId, "userIdentityId");
            var userIdentity = _storedProcedureExecutor.Execute<UserIdentityDto, UserDto>(userIdentityIdParameter, (ui, u) =>
            {
                ui.User = u;
                return ui;
            }, UserStoredProcedureEnum.GetUserIdentityById).First();

            var roles = _storedProcedureExecutor.Execute<RoleDto>(userIdentityIdParameter, UserStoredProcedureEnum.GetUserIdentityRoles).ToList();

            var rolesIdParameter = new IntList(roles.Select(x => x.Id).ToList()).AsTableValuedParameter("rolesId");
            var permissions = _storedProcedureExecutor.Execute<RolePermissionDto>(rolesIdParameter, UserStoredProcedureEnum.GetPermissionsByRolesId);

            roles.ForEach(x => x.Permissions = permissions.Where(y => y.RoleId == x.Id).Select(y => y.Permission).ToList());

            userIdentity.Roles = roles;

            return userIdentity;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var openId = new IdentityResources.OpenId();
            var subClaim = openId.UserClaims.First();

            var sub = context.Subject.Claims.FirstOrDefault(x => x.Type == subClaim); //identityuser ID
            if (sub == null)
                throw new Exception(); //todo exception

            var userIdentity = GetUserIdentity(int.Parse(sub.Value));

            var claims = ClaimTypeHelper.GetClaimsFromObject(userIdentity);

            throw new NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            //client verification

            var openId = new IdentityResources.OpenId();
            var subClaim = openId.UserClaims.First();

            var sub = context.Subject.Claims.FirstOrDefault(x => x.Type == subClaim); //identityuser ID
            if (sub == null)
            {
                context.IsActive = false;
                return Task.FromResult(context);
            }
            
            var userIdentityId = AsParameter(int.Parse(sub.Value), "userIdentityId");
            context.IsActive = _storedProcedureExecutor.ExecuteSingle<bool>(userIdentityId, UserStoredProcedureEnum.IsUserIdentityActive);

            return Task.FromResult(context.IsActive);
        }
    }
}

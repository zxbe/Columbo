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
        private readonly IUserIdentityService _userIdentityService;

        public ProfileService(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var openId = new IdentityResources.OpenId();
            var subClaim = openId.UserClaims.First();

            var sub = context.Subject.Claims.FirstOrDefault(x => x.Type == subClaim); //identityuser ID
            if (sub == null)
                throw new Exception(); //todo exception

            var userIdentity = _userIdentityService.GetUserIdentity(int.Parse(sub.Value));

            var claims = ClaimTypeHelper.GetRequiredClaimsFromObject(userIdentity, context.RequestedClaimTypes.ToList());

            context.IssuedClaims.AddRange(claims.ToList());

            return Task.CompletedTask;
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

            context.IsActive = _userIdentityService.IsUserIdentityActive(int.Parse(sub.Value));

            return Task.CompletedTask;
        }
    }
}

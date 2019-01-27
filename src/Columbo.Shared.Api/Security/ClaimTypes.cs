using Columbo.Shared.Api.Security.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Columbo.Shared.Api.Security
{
    public static class ClaimTypes
    {
        public const string UserIdentityId = "http://schemas.columbo.com/identity/claims/userIdentityId";
        public const string Login = "http://schemas.columbo.com/identity/claims/login";
        public const string Name = "http://schemas.columbo.com/identity/claims/name";
        public const string Surname = "http://schemas.columbo.com/identity/claims/surname";
        public const string EmailAddress = "http://schemas.columbo.com/identity/claims/emailAddress";
        public const string RoleTypeId = "http://schemas.columbo.com/identity/claims/roleTypeId";
        public const string PermissionId = "http://schemas.columbo.com/identity/claims/permissionId";

        public static Dictionary<string, string> GetClaimTypes()
        {
            var claimTypes = new Dictionary<string, string>();
            var fields = typeof(ClaimTypes).GetFields().Where(x => x.IsStatic);
           
            foreach (var field in fields)
            {
                string name = field.Name;
                string value = (string)field.GetValue(null);

                claimTypes.Add(name, value);
            }

            return claimTypes;
        }
    }
}

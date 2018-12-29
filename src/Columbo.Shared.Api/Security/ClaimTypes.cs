using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Shared.Api.Security
{
    public static class ClaimTypes
    {
        public static string UserId => "http://schemas.columbo.com/identity/claims/userId";
        public static string Login => "http://schemas.columbo.com/identity/claims/login";
        public static string Name => "http://schemas.columbo.com/identity/claims/name";
        public static string Surname => "http://schemas.columbo.com/identity/claims/surname";
        public static string EmailAddress => "http://schemas.columbo.com/identity/claims/emailAddress";
        public static string RoleType => "http://schemas.columbo.com/identity/claims/roleType";
        public static string RoleId => "http://schemas.columbo.com/identity/claims/roleId";
        public static string Permission => "http://schemas.columbo.com/identity/claims/permission";

        public static Dictionary<string, string> GetClaimTypes()
        {
            var claimTypes = new Dictionary<string, string>();
            var properties = typeof(ClaimTypes).GetProperties();
           
            foreach (var property in properties)
            {
                string name = property.Name;
                string value = (string)property.GetValue(null);

                claimTypes.Add(name, value);
            }

            return claimTypes;
        }
    }
}

using Columbo.Shared.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.StoredProcedures
{
    public enum UserStoredProcedureEnum
    {
        [SqlScript("PR_User_GetUserIdentityById.sql")]
        GetUserIdentityById,

        [SqlScript("PR_User_GetUserIdentityRoles.sql")]
        GetUserIdentityRoles,

        [SqlScript("PR_User_IsUserIdentityActive.sql")]
        IsUserIdentityActive,
        
        [SqlScript("PR_User_VerifyUserIdentity.sql")]
        VerifyUserIdentity
    }
}

using Columbo.Shared.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.StoredProcedures
{
    public enum ClientStoredProcedureEnum
    {
        [SqlScript("PR_Client_GetClientApiResources.sql")]
        GetClientApiResources,

        [SqlScript("PR_Client_GetClientByGuid.sql")]
        GetClientByGuid,

        [SqlScript("PR_Client_GetClientIdentityResources.sql")]
        GetClientIdentityResources,
    }
}

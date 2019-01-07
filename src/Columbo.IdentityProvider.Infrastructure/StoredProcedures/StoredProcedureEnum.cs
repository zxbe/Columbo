using Columbo.Shared.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.StoredProcedures
{
    public enum StoredProcedureEnum
    {
        //Client

        [SqlScript("PR_GetClientByGuid.sql")]
        GetClientByGuid,

        [SqlScript("PR_GetClientApiResources.sql")]
        GetClientApiResources,

        [SqlScript("PR_GetClientIdentityResources.sql")]
        GetClientIdentityResources,

        //Api resource

        [SqlScript("PR_GetAllApiResources.sql")]
        GetAllApiResources,

        [SqlScript("PR_GetApiResourceByName.sql")]
        GetApiResourceByName,

        [SqlScript("PR_GetApiResourcesByNames.sql")]
        GetApiResourcesByNames,

        [SqlScript("PR_GetApiResourceClaims.sql")]
        GetApiResourceClaims,

        //Identity resource

        [SqlScript("PR_GetAllIdentityResources.sql")]
        GetAllIdentityResources,

        [SqlScript("PR_GetIdentityResourcesByNames.sql")]
        GetIdentityResourcesByNames,

        [SqlScript("PR_GetIdentityResourceClaims.sql")]
        GetIdentityResourceClaims,

        //Instance

        [SqlScript("PR_GetInstancesByIds.sql")]
        GetInstancesByIds
    }
}

using Columbo.Shared.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.StoredProcedures
{
    public enum ResourceStoredProcedureEnum
    {
        [SqlScript("PR_Resource_GetAllApiResources.sql")]
        GetAllApiResources,

        [SqlScript("PR_Resource_GetAllIdentityResources.sql")]
        GetAllIdentityResources,

        [SqlScript("PR_Resource_GetApiResourceByName.sql")]
        GetApiResourceByName,

        [SqlScript("PR_Resource_GetApiResourcesByNames.sql")]
        GetApiResourcesByNames,

        [SqlScript("PR_Resource_GetIdentityResourcesByNames.sql")]
        GetIdentityResourcesByNames
    }
}

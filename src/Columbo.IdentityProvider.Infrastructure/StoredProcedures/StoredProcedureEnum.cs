using Columbo.Shared.Infrastructure.Sql.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.StoredProcedures
{
    public enum StoredProcedureEnum
    {
        [SqlScript("PR_GetClientByGuid.sql")]
        GetClientByGuid,

        [SqlScript("PR_GetApiResources.sql")]
        GetApiResources,

        [SqlScript("PR_GetApiResourceByName.sql")]
        GetApiResourceByName,

        [SqlScript("PR_GetApiResourcesByNames.sql")]
        GetApiResourcesByNames,

        [SqlScript("PR_GetIdentityResources.sql")]
        GetIdentityResources,

        [SqlScript("PR_GetIdentityResourcesByNames.sql")]
        GetIdentityResourcesByNames
    }
}

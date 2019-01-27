using Columbo.Shared.Api.Security.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class ClaimTypeAttribute : Attribute
    { 
        public string ClaimType { get; }
        public ClaimTypeTargetEnum Target { get; }
        
        public ClaimTypeAttribute()
        {
            Target = ClaimTypeTargetEnum.Complex;
        }

        public ClaimTypeAttribute(string claimType, ClaimTypeTargetEnum target = ClaimTypeTargetEnum.BuiltIn)
        {
            if (string.IsNullOrEmpty(claimType))
                throw new Exception(); //todo exception

            if (target == ClaimTypeTargetEnum.Collection || target == ClaimTypeTargetEnum.Complex)
                throw new Exception(); //todo exception
            
            ClaimType = claimType;
            Target = target;
        }

        public ClaimTypeAttribute(ClaimTypeTargetEnum target)
        {
            if (target == ClaimTypeTargetEnum.BuiltIn || target == ClaimTypeTargetEnum.EnumCollection)
                throw new Exception(); //todo exception required ClaimType

            Target = target;
        }
    }
}

﻿using Columbo.IdentityProvider.Service.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Columbo.IdentityProvider.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IdentityProviderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IdentityProviderService.svc or IdentityProviderService.svc.cs at the Solution Explorer and start debugging.
    public class IdentityProviderService : IIdentityProviderService
    {
        public void TokenTest()
        {
            throw new NotImplementedException();
        }

        public void UserTest()
        {
            throw new NotImplementedException();
        }
    }
}

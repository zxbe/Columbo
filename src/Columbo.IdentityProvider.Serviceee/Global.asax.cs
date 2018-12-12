using Autofac;
using Autofac.Integration.Wcf;
using Columbo.IdentityProvider.Service.Startup;
using Columbo.Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Columbo.IdentityProvider.Service
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = ContainerConfig.Create();

            using (var scope = container.BeginLifetimeScope())
            {
                var dbContext = scope.Resolve<IDatabaseContext>();
                DatabaseConfig.Initialing(dbContext);
            }

            AutofacHostFactory.Container = container;
        }
    }
}
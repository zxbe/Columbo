using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Columbo.Shared.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Columbo.IdentityProvider.Api
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.Register(c => Configuration).As<IConfiguration>().SingleInstance();
            builder.RegisterModule<Columbo.IdentityProvider.Api.Container.ContainerModule>();
            builder.RegisterModule<Columbo.IdentityProvider.Infrastructure.Container.ContainerModule>();

            ApplicationContainer = builder.Build();

            ConfigureDatabase();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        private void ConfigureDatabase()
        {
            var databaseContext = ApplicationContainer.Resolve<IDatabaseContext>();
            databaseContext.InitializeDatabase();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}

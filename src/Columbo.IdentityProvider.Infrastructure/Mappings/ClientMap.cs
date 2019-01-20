using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class ClientMap : AggregateRootMap<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            builder.ToTable("Client");

            builder.Property(x => x.ClientGuid);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.SecretHash).HasMaxLength(64).IsRequired();
            builder.Property(x => x.RedirectUri).HasConversion<string>(x => x.AbsoluteUri, y => new Uri(y)).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PostLogoutRedirectUri).HasConversion<string>(x => x.AbsoluteUri, y => new Uri(y)).HasMaxLength(50).IsRequired();
            builder.Property(x => x.IdentityTokenLifetime);
            builder.Property(x => x.AccessTokenLifetime);
            builder.Property(x => x.SequrityCodeLifetiem);
            builder.Property(x => x.IsActive);
        }
    }
}

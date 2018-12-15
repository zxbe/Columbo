using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Columbo.IdentityProvider.Core.ValueObjects
{
    public class IpAddress : IPAddress
    {
        public new string Address => base.ToString();

        public IpAddress()
            : base(192168001001)
        {
        }

        public IpAddress(long address)
            : base(address)
        {
        }

        public IpAddress(byte[] address)
            : base(address)
        {
        }

        public IpAddress(byte[] address, long scopeId)
            : base(address, scopeId)
        {
        }
    }
}

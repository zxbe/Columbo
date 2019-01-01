using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Infrastructure.Exceptions
{
    public class AttributeNotFoundException : Exception
    {
        public AttributeNotFoundException()
            : base("Attribute not found")
        {
        }

        public AttributeNotFoundException(string message)
            : base(message)
        {
        }

        public AttributeNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

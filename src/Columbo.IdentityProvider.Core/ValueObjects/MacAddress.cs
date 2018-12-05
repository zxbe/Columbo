using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Columbo.IdentityProvider.Core.ValueObjects
{
    public class MacAddress
    {
        public string Address { get; private set; }
        public string[] AddressParts => Address.Split(':');
        
        public MacAddress(string macAddress)
        {
            if (!Valid(macAddress))
                throw new ArgumentException("Mac address is now valid");

            Address = macAddress;
        }

        private bool Valid(string macAddress)
        {
            var regex = "^([0-9A-F]{2}[:]){5}([0-9A-F]{2})$";

            return Regex.Match(macAddress, regex).Success;
        }

        public override string ToString()
        {
            return Address;
        }
    }
}

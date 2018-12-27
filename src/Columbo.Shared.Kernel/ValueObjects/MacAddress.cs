using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Columbo.Shared.Kernel.ValueObjects
{
    public class MacAddress
    {
        private string _address;

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (Valid(value))
                    _address = value;
                else
                    throw new ArgumentException("Mac address is now valid");
            }
        }
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

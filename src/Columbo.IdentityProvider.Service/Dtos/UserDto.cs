using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Columbo.IdentityProvider.Service.Dtos
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
    }
}
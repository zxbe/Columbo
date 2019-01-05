using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Dtos
{
    public class ManagedBaseDto : BaseDto
    {
        public DateTime? UpdateDate { get; set; }
    }
}

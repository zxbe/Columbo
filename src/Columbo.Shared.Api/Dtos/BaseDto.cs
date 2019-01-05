using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

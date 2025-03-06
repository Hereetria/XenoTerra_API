using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.FollowDtos
{
    public class ResultFollowDto
    {
        public Guid FollowId { get; set; }
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
        public DateTime FollowedAt { get; set; }
    }
}

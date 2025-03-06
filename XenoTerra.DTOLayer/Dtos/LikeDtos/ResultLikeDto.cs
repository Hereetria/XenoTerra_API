using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.LikeDtos
{
    public class ResultLikeDto
    {
        public Guid LikeId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}

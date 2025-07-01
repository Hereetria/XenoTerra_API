using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin
{
    public class ResultPostLikeAdminDto
    {
        public Guid PostLikeId { get; init; }
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin
{
    public class ResultStoryLikeAdminDto
    {
        public Guid StoryLikeId { get; init; }
        public Guid StoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
    }
}

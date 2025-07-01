using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin
{
    public class CreateStoryLikeAdminDto
    {
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}

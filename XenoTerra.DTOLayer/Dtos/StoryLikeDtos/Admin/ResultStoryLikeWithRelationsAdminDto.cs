using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin
{
    public class ResultStoryLikeWithRelationsAdminDto
    {
        public Guid StoryLikeId { get; init; }
        public Guid StoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }

        public ResultStoryAdminDto Story { get; set; } = new();
        public ResultAppUserAdminDto User { get; set; } = new();
    }
}

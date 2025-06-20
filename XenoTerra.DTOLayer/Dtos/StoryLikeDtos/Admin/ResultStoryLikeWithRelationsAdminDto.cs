using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Admin
{
    public class ResultStoryLikeWithRelationsAdminDto
    {
        public Guid StoryLikeId { get; set; }
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }

        public ResultStoryAdminDto Story { get; set; } = new();
        public ResultAppUserAdminDto User { get; set; } = new();
    }
}

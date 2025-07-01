using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin
{
    public class ResultViewStoryWithRelationsAdminDto
    {
        public Guid ViewStoryId { get; init; }
        public Guid StoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime ViewedAt { get; init; }
        public ResultStoryWithRelationsAdminDto Story { get; set; } = new();
        public ResultAppUserWithRelationsAdminDto User { get; set; } = new();
    }
}
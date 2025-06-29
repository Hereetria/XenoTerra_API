using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Admin
{
    public class ResultHighlightWithRelationsAdminDto
    {
        public Guid HighlightId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ProfilePicturePath { get; init; } = string.Empty;
        public Guid UserId { get; set; }
        public AppUser User { get; init; } = null!;
        public ICollection<ResultStoryAdminDto> Stories { get; init; } = [];
    }
}
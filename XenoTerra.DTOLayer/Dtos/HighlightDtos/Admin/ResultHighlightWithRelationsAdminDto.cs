using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin
{
    public class ResultHighlightWithRelationsAdminDto
    {
        public Guid HighlightId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ProfilePicturePath { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public AppUser User { get; init; } = null!;
        public ICollection<ResultStoryAdminDto> Stories { get; set; } = [];
    }
}
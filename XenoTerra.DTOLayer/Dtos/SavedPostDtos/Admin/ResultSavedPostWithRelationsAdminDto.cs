using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin
{
    public class ResultSavedPostWithRelationsAdminDto
    {
        public Guid SavedPostId { get; init; }
        public Guid UserId { get; init; }
        public Guid PostId { get; init; }
        public DateTime SavedAt { get; init; }
        public ResultAppUserAdminDto User { get; set; } = new();
        public ResultPostAdminDto Post { get; set; } = new();   
    }
}
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin
{
    public class ResultBlockUserWithRelationsAdminDto
    {
        public Guid BlockUserId { get; init; }
        public Guid BlockingUserId { get; init; }
        public Guid BlockedUserId { get; init; }
        public DateTime BlockedAt { get; init; }
        public ResultAppUserAdminDto BlockingUser { get; set; } = new();
        public ResultAppUserAdminDto BlockedUser { get; set; } = new();
    }
}
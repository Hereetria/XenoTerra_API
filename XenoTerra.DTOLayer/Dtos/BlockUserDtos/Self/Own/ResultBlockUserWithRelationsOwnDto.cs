using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own
{
    public class ResultBlockUserWithRelationsOwnDto
    {
        public Guid BlockUserId { get; init; }
        public Guid BlockingUserId { get; init; }
        public Guid BlockedUserId { get; init; }
        public DateTime BlockedAt { get; init; }
        public ResultAppUserOwnDto BlockingUser { get; set; } = new();
        public ResultAppUserOwnDto BlockedUser { get; set; } = new();
    }
}
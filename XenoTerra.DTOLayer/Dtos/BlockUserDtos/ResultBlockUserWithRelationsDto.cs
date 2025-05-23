

using HotChocolate;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public record class ResultBlockUserWithRelationsDto
    {
        public Guid BlockUserId { get; init; }
        public Guid BlockingUserId { get; init; }
        public Guid BlockedUserId { get; init; }
        public DateTime BlockedAt { get; init; }
        public ResultUserPrivateDto BlockingUser { get; init; } = new();
        public ResultUserPrivateDto BlockedUser { get; init; } = new();
    }
}
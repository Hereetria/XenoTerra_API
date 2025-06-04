

using HotChocolate;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public record class ResultBlockUserWithRelationsDto
    {
        public Guid BlockUserId { get; init; }
        public Guid BlockingUserId { get; init; }
        public Guid BlockedUserId { get; init; }
        public DateTime BlockedAt { get; init; }
        public ResultAppUserPrivateDto BlockingUser { get; init; } = new();
        public ResultAppUserPrivateDto BlockedUser { get; init; } = new();
    }
}
namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own
{
    public class ResultBlockUserOwnDto
    {
        public Guid BlockUserId { get; init; }
        public Guid BlockingUserId { get; init; }
        public Guid BlockedUserId { get; init; }
        public DateTime BlockedAt { get; init; }
    }
}
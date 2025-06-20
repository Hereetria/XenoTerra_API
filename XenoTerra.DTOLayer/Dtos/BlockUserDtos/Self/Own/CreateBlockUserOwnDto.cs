namespace XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Self.Own
{
    public class CreateBlockUserOwnDto
    {
        public Guid BlockingUserId { get; set; }
        public Guid BlockedUserId { get; set; }
        public DateTime BlockedAt { get; set; }
    }
}

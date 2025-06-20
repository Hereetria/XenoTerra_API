namespace XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin
{
    public class CreateBlockUserAdminDto
    {
        public Guid BlockingUserId { get; set; }
        public Guid BlockedUserId { get; set; }
        public DateTime BlockedAt { get; set; }
    }
}
namespace XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin
{
    public class UpdateBlockUserAdminDto
    {
        public Guid BlockUserId { get; set; }
        public Guid? BlockingUserId { get; set; }
        public Guid? BlockedUserId { get; set; }
    }
}
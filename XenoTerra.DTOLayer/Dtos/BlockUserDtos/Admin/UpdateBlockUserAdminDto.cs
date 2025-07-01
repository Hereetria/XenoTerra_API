namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin
{
    public class UpdateBlockUserAdminDto
    {
        public Guid BlockUserId { get; set; }
        public Guid? BlockingUserId { get; set; }
        public Guid? BlockedUserId { get; set; }
    }
}
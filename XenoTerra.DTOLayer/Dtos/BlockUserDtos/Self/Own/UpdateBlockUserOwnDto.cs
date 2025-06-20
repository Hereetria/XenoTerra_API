namespace XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Self.Own
{
    public class UpdateBlockUserOwnDto
    {
        public Guid BlockUserId { get; set; }
        public Guid? BlockingUserId { get; set; }
        public Guid? BlockedUserId { get; set; }
    }
}


namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public class UpdateBlockUserDto
    {
        public Guid BlockUserId { get; set; }
        public Guid? BlockingUserId { get; set; }
        public Guid? BlockedUserId { get; set; }
    }
}



namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public class CreateCommentckUserDto
    {
        public Guid BlockingUserId { get; set; }
        public Guid BlockedUserId { get; set; }
        public DateTime BlockedAt { get; set; }
    }
}
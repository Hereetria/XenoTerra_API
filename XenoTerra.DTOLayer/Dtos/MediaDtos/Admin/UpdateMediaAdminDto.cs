namespace XenoTerra.DTOLayer.Dtos.MediaDtos.Admin
{
    public class UpdateMediaAdminDto
    {
        public Guid MediaId { get; set; }
        public string? PhotoUrl { get; set; } = string.Empty;

        public Guid? SenderId { get; set; }

        public Guid? ReceiverId { get; set; }

        public DateTime? UploadedAt { get; set; }
    }
}
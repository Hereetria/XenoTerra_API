namespace XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Self.Own
{
    public class UpdateMediaOwnDto
    {
        public Guid MediaId { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;

        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}

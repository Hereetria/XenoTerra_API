using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Admin
{
    public class CreateMediaAdminDto
    {
        public string PhotoUrl { get; set; } = string.Empty;

        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
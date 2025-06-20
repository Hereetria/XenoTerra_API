using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Self.Own
{
    public class ResultMediaWithRelationsOwnDto
    {
        public Guid MediaId { get; init; }
        public string PhotoUrl { get; init; } = string.Empty;

        public Guid SenderId { get; init; }

        public Guid ReceiverId { get; init; }

        public DateTime UploadedAt { get; init; }
        public AppUser Sender { get; set; } = new();
        public AppUser Receiver { get; set; } = new();
    }
}
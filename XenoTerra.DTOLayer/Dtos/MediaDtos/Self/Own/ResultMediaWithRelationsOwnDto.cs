using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own
{
    public class ResultMediaWithRelationsOwnDto
    {
        public Guid MediaId { get; init; }
        public string PhotoUrl { get; init; } = string.Empty;

        public Guid SenderId { get; init; }

        public Guid ReceiverId { get; init; }

        public DateTime UploadedAt { get; init; }
        public AppUser Sender { get; init; } = new();
        public AppUser Receiver { get; init; } = new();
    }
}
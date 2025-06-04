

using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.DTOLayer.Dtos.MediaDtos
{
    public record class ResultMediaWithRelationsDto
    {
        public Guid MediaId { get; init; }
        public string PhotoUrl { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime UploadedAt { get; init; }
        public ResultAppUserPrivateDto User { get; init; } = new();
    }
}
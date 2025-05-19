

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MediaDtos
{
    public record class ResultMediaWithRelationsDto
    {
        public Guid MediaId { get; init; }
        public string PhotoUrl { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime UploadedAt { get; init; }
        public ResultUserPrivateDto User { get; init; } = new();
    }
}
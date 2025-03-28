

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MediaDtos
{
    public record ResultMediaWithRelationsDto(
        Guid MediaId,
        string PhotoUrl,
        Guid UserId,
        DateTime UploadedAt
    )
    {
        public ResultUserDto? User { get; set; }
    }
}
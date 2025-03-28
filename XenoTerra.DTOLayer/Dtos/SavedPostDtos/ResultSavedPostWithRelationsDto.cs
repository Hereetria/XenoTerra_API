

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos
{
public record ResultSavedPostWithRelationsDto(
    Guid SavedPostId,
    Guid UserId,
    Guid PostId,
    DateTime SavedAt
);
}
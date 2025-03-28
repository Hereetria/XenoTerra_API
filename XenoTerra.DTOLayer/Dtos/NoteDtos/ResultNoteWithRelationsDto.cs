

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.NoteDtos
{
    public record ResultNoteWithRelationsDto(
        Guid NoteId,
        string Text,
        Guid UserId,
        DateTime CreatedAt
    )
    {
        public ResultUserDto? User { get; set; }
    }
}
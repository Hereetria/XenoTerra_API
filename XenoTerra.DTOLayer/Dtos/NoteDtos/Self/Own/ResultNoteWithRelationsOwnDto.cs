using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own
{
    public class ResultNoteWithRelationsOwnDto
    {
        public Guid NoteId { get; init; }
        public string Text { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserOwnDto User { get; set; } = new();
    }
}
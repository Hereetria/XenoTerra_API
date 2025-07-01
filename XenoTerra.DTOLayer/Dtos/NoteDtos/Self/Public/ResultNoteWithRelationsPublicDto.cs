using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;

namespace XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Public
{
    public class ResultNoteWithRelationsPublicDto
    {
        public Guid NoteId { get; init; }
        public string Text { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserPublicDto User { get; set; } = new();
    }
}
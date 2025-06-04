

using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.DTOLayer.Dtos.NoteDtos
{
    public record class ResultNoteWithRelationsDto
    {
        public Guid NoteId { get; init; }
        public string Text { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserPrivateDto User { get; init; } = new();
    }
}
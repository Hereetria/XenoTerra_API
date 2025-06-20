namespace XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Public
{
    public class ResultNotePublicDto
    {
        public Guid NoteId { get; init; }
        public string Text { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
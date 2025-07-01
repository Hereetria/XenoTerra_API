namespace XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own
{
    public class ResultNoteOwnDto
    {
        public Guid NoteId { get; init; }
        public string Text { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
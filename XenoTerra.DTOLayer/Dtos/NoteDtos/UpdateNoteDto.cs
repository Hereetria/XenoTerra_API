


namespace XenoTerra.DTOLayer.Dtos.NoteDtos
{
    public class UpdateNoteDto
    {
        public Guid NoteId { get; set; }
        public string? Text { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
    }
}
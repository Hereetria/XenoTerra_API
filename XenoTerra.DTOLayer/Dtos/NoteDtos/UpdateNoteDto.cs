

namespace XenoTerra.DTOLayer.Dtos.NoteDtos
{
    public class UpdateNoteDto
    {
        public Guid NoteId { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
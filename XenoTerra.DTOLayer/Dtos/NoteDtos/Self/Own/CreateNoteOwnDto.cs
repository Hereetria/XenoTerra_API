namespace XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Own
{
    public class CreateNoteOwnDto
    {
        public string Text { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

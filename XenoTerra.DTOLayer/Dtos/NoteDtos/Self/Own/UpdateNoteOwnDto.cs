namespace XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Own
{
    public class UpdateNoteOwnDto
    {
        public Guid NoteId { get; set; }
        public string? Text { get; set; } = string.Empty;
    }
}

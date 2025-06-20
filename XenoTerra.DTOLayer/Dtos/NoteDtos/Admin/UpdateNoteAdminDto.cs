namespace XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Admin
{
    public class UpdateNoteAdminDto
    {
        public Guid NoteId { get; set; }
        public string? Text { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
    }
}
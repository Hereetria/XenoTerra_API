namespace XenoTerra.DTOLayer.Dtos.NoteDtos.Admin
{
    public class CreateNoteAdminDto
    {
        public string Text { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
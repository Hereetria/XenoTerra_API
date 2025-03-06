

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.NoteDtos
{
    public class CreateNoteDto
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}


using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.NoteDtos
{
    public class ResultNoteWithRelationsDto
    {
        public Guid NoteId { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ResultUserDto User { get; set; }
    }
}
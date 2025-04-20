using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.NoteDtos
{
    public record class ResultNoteDto
    {
        public Guid NoteId { get; init; }
        public string Text { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}

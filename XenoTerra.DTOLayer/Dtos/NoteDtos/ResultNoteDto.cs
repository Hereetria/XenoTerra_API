using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.NoteDtos
{
    public class ResultNoteDto
    {
        public Guid NoteId { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.NoteDtos
{
    public record ResultNoteDto(
        Guid NoteId,
        string Text,
        Guid UserId,
        DateTime CreatedAt
    );
}

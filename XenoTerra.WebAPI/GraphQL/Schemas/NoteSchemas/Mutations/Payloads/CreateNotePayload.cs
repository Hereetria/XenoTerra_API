using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Mutations.Payloads
{
    public record CreateNotePayload : Payload<ResultNoteDto>;
}

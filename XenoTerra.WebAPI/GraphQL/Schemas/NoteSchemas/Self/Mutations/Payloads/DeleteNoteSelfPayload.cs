using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Payloads
{
    public record DeleteNoteSelfPayload : Payload<ResultNoteDto>;
}

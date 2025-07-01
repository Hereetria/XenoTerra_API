using XenoTerra.DTOLayer.Dtos.NoteDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads
{
    public record UpdateNoteAdminPayload : Payload<ResultNoteAdminDto>;
}

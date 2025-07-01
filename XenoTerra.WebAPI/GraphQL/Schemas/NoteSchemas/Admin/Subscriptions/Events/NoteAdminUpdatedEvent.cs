using XenoTerra.DTOLayer.Dtos.NoteDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events
{
    public record NoteAdminUpdatedEvent : UpdatedEvent<ResultNoteAdminDto>
    {
    }
}
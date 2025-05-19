using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events
{
    public record NoteSelfUpdatedEvent : UpdatedEvent<ResultNoteDto>
    {
    }
}
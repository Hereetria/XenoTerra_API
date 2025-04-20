using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Subscriptions.Events
{
    public record NoteUpdatedEvent : UpdatedEvent<ResultNoteDto>
    {
    }
}
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events
{
    public record NoteDeletedEvent : DeletedEvent<ResultNoteDto>
    {
    }
}
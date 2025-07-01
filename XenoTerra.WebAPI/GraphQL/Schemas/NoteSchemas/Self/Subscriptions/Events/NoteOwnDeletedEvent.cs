using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events
{
    public record NoteOwnDeletedEvent : DeletedEvent<ResultNoteOwnDto>
    {
    }
}
using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events
{
    public record NoteOwnCreatedEvent : CreatedEvent<ResultNoteOwnDto>
    {
    }
}                                                                                                                                                                                                                                                                     
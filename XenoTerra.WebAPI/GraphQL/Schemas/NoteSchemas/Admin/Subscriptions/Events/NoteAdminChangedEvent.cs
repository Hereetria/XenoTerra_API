using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events
{
    public record NoteAdminChangedEvent : ChangedEvent<ResultNoteDto>
    {
    }
}                                                                                                                                                                                                                                                                     
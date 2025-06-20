using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events
{
    public record NoteAdminCreatedEvent : CreatedEvent<ResultNoteAdminDto>
    {
    }
}                                                                                                                                                                                                                                                                     
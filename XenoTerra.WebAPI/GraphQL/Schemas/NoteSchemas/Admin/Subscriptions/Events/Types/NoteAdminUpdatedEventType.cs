using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteAdminUpdatedEventType : ObjectType<NoteAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteAdminUpdatedEvent> descriptor)
        {
        }
    }
}
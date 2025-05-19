using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteAdminCreatedEventType : ObjectType<NoteAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteAdminCreatedEvent> descriptor)
        {
        }
    }
}
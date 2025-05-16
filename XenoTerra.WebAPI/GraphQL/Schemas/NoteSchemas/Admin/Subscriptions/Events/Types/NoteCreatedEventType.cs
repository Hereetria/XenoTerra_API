using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteCreatedEventType : ObjectType<NoteCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteCreatedAdminEvent> descriptor)
        {
        }
    }
}
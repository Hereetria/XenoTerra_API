using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteAdminChangedEventType : ObjectType<NoteAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteAdminChangedEvent> descriptor)
        {
        }
    }
}
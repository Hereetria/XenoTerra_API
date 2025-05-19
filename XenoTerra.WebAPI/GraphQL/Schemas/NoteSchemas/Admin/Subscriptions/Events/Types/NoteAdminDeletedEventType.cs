using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteAdminDeletedEventType : ObjectType<NoteAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteAdminDeletedEvent> descriptor)
        {
        }
    }
}
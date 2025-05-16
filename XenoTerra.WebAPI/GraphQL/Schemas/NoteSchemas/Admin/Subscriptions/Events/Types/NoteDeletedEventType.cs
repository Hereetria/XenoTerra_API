using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteDeletedEventType : ObjectType<NoteDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteDeletedAdminEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteChangedEventType : ObjectType<NoteChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteChangedAdminEvent> descriptor)
        {
        }
    }
}
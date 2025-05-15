using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events.Types
{
    public class NoteChangedEventType : ObjectType<NoteChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteChangedEvent> descriptor)
        {
        }
    }
}
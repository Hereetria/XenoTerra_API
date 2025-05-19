using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events.Types
{
    public class NoteSelfDeletedEventType : ObjectType<NoteSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteSelfDeletedEvent> descriptor)
        {
        }
    }
}
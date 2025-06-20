using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events.Types
{
    public class NoteOwnDeletedEventType : ObjectType<NoteOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteOwnDeletedEvent> descriptor)
        {
        }
    }
}
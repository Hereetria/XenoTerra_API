using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events.Types
{
    public class NoteOwnUpdatedEventType : ObjectType<NoteOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteOwnUpdatedEvent> descriptor)
        {
        }
    }
}
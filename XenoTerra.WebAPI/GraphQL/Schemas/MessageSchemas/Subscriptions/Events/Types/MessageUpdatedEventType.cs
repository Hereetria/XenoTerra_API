namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions.Events.Types
{
    public class MessageUpdatedEventType : ObjectType<MessageUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageUpdatedEvent> descriptor)
        {
        }
    }
}

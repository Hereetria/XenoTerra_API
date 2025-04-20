namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions.Events.Types
{
    public class MessageDeletedEventType : ObjectType<MessageDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageDeletedEvent> descriptor)
        {
        }
    }
}

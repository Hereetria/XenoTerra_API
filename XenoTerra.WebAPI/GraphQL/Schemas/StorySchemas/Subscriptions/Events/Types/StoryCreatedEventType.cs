namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Subscriptions.Events.Types
{
    public class StoryCreatedEventType : ObjectType<StoryCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryCreatedEvent> descriptor)
        {
        }
    }
}
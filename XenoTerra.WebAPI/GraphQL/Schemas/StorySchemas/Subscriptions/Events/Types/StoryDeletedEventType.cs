namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Subscriptions.Events.Types
{
    public class StoryDeletedEventType : ObjectType<StoryDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryDeletedEvent> descriptor)
        {
        }
    }
}
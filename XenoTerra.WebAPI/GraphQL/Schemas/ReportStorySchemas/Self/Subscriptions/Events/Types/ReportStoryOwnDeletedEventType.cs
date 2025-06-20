using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions.Events.Types
{
    public class ReportStoryOwnDeletedEventType : ObjectType<ReportStoryOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportStoryOwnDeletedEvent> descriptor)
        {
        }
    }
}

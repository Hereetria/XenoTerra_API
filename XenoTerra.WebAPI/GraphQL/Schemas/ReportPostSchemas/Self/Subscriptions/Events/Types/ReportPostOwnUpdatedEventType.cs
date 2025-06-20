using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events.Types
{
    public class ReportPostOwnUpdatedEventType : ObjectType<ReportPostOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostOwnUpdatedEvent> descriptor)
        {
        }
    }
}
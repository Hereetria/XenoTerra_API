using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events.Types
{
    public class ReportPostSelfChangedEventType : ObjectType<ReportPostSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostSelfChangedEvent> descriptor)
        {
        }
    }
}
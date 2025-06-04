using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Paginations.Types
{
    public class ReportPostSelfConnectionType : ObjectType<ReportPostSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Paginations.Own.Types
{
    public class ReportPostOwnConnectionType : ObjectType<ReportPostOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

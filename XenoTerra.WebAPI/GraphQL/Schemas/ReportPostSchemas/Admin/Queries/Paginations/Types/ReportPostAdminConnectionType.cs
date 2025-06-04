using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries.Paginations.Types
{
    public class ReportPostAdminConnectionType : ObjectType<ReportPostAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

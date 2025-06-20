using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries.Paginations.Types
{
    public class ReportStoryAdminConnectionType : ObjectType<ReportStoryAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportStoryAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

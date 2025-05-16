using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Paginations.Types
{
    public class HighlightAdminConnectionType : ObjectType<HighlightAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Paginations.Types
{
    public class HighlightSelfConnectionType : ObjectType<HighlightSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

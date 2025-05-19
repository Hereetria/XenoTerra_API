using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Types
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

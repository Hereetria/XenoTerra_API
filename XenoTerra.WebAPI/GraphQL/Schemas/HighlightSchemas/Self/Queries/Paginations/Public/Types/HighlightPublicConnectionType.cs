using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Public.Types
{
    public class HighlightPublicConnectionType : ObjectType<HighlightPublicConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightPublicConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

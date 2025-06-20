using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Own.Types
{
    public class HighlightOwnConnectionType : ObjectType<HighlightOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

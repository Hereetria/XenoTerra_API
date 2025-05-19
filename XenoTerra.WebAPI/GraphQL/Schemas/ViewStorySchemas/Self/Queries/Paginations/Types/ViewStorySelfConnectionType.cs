using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Paginations.Types
{
    public class ViewStorySelfConnectionType : ObjectType<ViewStorySelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStorySelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

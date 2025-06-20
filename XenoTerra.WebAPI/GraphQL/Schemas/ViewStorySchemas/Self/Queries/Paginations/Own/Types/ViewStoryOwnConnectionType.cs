using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Paginations.Own.Types
{
    public class ViewStoryOwnConnectionType : ObjectType<ViewStoryOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

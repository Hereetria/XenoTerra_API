using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations.Types
{
    public class StorySelfConnectionType : ObjectType<StorySelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StorySelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

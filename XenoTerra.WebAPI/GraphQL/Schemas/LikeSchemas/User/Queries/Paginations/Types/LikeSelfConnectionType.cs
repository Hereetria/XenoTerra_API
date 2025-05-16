using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Paginations.Types
{
    public class LikeSelfConnectionType : ObjectType<LikeSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

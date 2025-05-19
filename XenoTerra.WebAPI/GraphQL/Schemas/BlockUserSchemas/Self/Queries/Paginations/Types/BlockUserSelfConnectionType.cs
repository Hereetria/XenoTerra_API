using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Paginations.Types
{
    public class BlockUserSelfConnectionType : ObjectType<BlockUserSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

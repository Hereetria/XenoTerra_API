using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Paginations
{
    public class BlockUserConnectionType : ObjectType<BlockUserConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}

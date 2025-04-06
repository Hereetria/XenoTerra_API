using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Types.Paginations
{
    public class BlockUserConnectionType : ObjectType<Connection<ResultBlockUserWithRelationsDto>>
    {
        protected override void Configure(IObjectTypeDescriptor<Connection<ResultBlockUserWithRelationsDto>> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();

            descriptor.Field(x => x.Info)
                .Type<NonNullType<PageInfoType>>();

            descriptor.Field(x => x.Edges)
                .Type<NonNullType<ListType<NonNullType<BlockUserEdgeType>>>>();
        }
    }
}

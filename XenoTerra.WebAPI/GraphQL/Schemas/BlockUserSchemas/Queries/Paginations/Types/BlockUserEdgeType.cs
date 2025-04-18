﻿using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Paginations
{
    public class BlockUserEdgeType : ObjectType<BlockUserEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserEdge> descriptor)
        {
        }
    }
}

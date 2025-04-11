using AutoMapper;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries
{
    public class BlockUserQuery(IMapper mapper, IQueryResolverHelper<BlockUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<BlockUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(BlockUserFilterType))]
        [UseSorting(typeof(BlockUserSortType))]
        public async Task<BlockUserConnection> GetAllBlockUsersAsync(
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<BlockUser, ResultBlockUserWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return new BlockUserConnection(connection.Edges, connection.Info, connection.TotalCount);
        }



        [UseCustomPaging]
        [UseFiltering(typeof(BlockUserFilterType))]
        [UseSorting(typeof(BlockUserSortType))]
        public async Task<BlockUserConnection> GetBlockUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<BlockUser, ResultBlockUserWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return new BlockUserConnection(connection.Edges, connection.Info, connection.TotalCount);
        }

        public async Task<ResultBlockUserWithRelationsDto?> GetBlockUserByIdAsync(
            string? key,
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultBlockUserWithRelationsDto>(entity);
        }
    }
}

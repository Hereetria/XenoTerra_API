using AutoMapper;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries
{
    public class BlockUserQuery(IMapper mapper, IQueryResolverHelper<BlockUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException();
        private readonly IQueryResolverHelper<BlockUser, Guid> _queryResolver = queryResolver;

        [UsePaging]
        [UseFiltering(typeof(BlockUserFilterType))]
        [UseSorting(typeof(BlockUserSortType))]
        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetAllBlockUsersAsync(
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultBlockUserWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(BlockUserFilterType))]
        [UseSorting(typeof(BlockUserSortType))]
        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetBlockUsersByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultBlockUserWithRelationsDto>>(entities);
        }

        public async Task<ResultBlockUserWithRelationsDto> GetBlockUserByIdAsync(
            Guid key,
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultBlockUserWithRelationsDto>(entity);
        }
    }

}

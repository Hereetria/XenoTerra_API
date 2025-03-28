using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries
{
    public class UserQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<User, Guid> _queryResolver;

        public UserQuery(IMapper mapper, IQueryResolverHelper<User, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(UserFilterType))]
        [UseSorting(typeof(UserSortType))]
        public async Task<IEnumerable<ResultUserWithRelationsDto>> GetAllUsersAsync(
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultUserWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(UserFilterType))]
        [UseSorting(typeof(UserSortType))]
        public async Task<IEnumerable<ResultUserWithRelationsDto>> GetStoriesByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultUserWithRelationsDto>>(entities);
        }

        public async Task<ResultUserWithRelationsDto> GetUserByIdAsync(
            Guid key,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultUserWithRelationsDto>(entity);
        }
    }
}

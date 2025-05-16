using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Queries
{
    public class UserAdminQuery(IMapper mapper, IQueryResolverHelper<User, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<User, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserAdminFilterType))]
        [UseSorting(typeof(UserAdminSortType))]
        public async Task<UserAdminConnection> GetAllUsersAsync(
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<User, ResultUserWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserAdminConnection, ResultUserWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserAdminFilterType))]
        [UseSorting(typeof(UserAdminSortType))]
        public async Task<UserAdminConnection> GetUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<User, ResultUserWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserAdminConnection, ResultUserWithRelationsDto>(connection);
        }

        public async Task<ResultUserWithRelationsDto?> GetUserByIdAsync(
            string? key,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultUserWithRelationsDto>(entity);
        }
    }
}

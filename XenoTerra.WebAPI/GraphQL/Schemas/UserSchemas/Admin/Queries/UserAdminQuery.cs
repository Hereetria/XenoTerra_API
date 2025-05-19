using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
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

            var connection = ConnectionMapper.MapConnection<User, ResultUserWithRelationsPrivateDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserAdminConnection, ResultUserWithRelationsPrivateDto>(connection);
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

            var connection = ConnectionMapper.MapConnection<User, ResultUserWithRelationsPrivateDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserAdminConnection, ResultUserWithRelationsPrivateDto>(connection);
        }

        public async Task<ResultUserWithRelationsPrivateDto?> GetUserByIdAsync(
            string? key,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserWithRelationsPrivateDto>(entity);
        }
    }
}

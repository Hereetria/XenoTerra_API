using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserPostTagResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class UserPostTagAdminQuery(IMapper mapper, IQueryResolverHelper<UserPostTag, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<UserPostTag, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserPostTagAdminFilterType))]
        [UseSorting(typeof(UserPostTagAdminSortType))]
        public async Task<UserPostTagAdminConnection> GetAllUserPostTagsAsync(
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserPostTag, ResultUserPostTagWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPostTagAdminConnection, ResultUserPostTagWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserPostTagAdminFilterType))]
        [UseSorting(typeof(UserPostTagAdminSortType))]
        public async Task<UserPostTagAdminConnection> GetUserPostTagsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserPostTag, ResultUserPostTagWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPostTagAdminConnection, ResultUserPostTagWithRelationsAdminDto>(connection);
        }

        public async Task<ResultUserPostTagWithRelationsAdminDto?> GetUserPostTagByIdAsync(
            string? key,
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserPostTagWithRelationsAdminDto>(entity);
        }
    }
}

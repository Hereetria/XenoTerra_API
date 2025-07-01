using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.FollowResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class FollowAdminQuery(IMapper mapper, IQueryResolverHelper<Follow, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Follow, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(FollowAdminFilterType))]
        [UseSorting(typeof(FollowAdminSortType))]
        public async Task<FollowAdminConnection> GetAllFollowsAsync(
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Follow, ResultFollowWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowAdminConnection, ResultFollowWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(FollowAdminFilterType))]
        [UseSorting(typeof(FollowAdminSortType))]
        public async Task<FollowAdminConnection> GetFollowsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Follow, ResultFollowWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowAdminConnection, ResultFollowWithRelationsAdminDto>(connection);
        }

        public async Task<ResultFollowWithRelationsAdminDto?> GetFollowByIdAsync(
            string? key,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultFollowWithRelationsAdminDto>(entity);
        }
    }

}

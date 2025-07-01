using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.StoryLikeResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryLikeQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class StoryLikeAdminQuery(IMapper mapper, IQueryResolverHelper<StoryLike, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<StoryLike, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(StoryLikeAdminFilterType))]
        [UseSorting(typeof(StoryLikeAdminSortType))]
        public async Task<StoryLikeAdminConnection> GetAllStoryLikesAsync(
            [Service] IStoryLikeQueryService service,
            [Service] IStoryLikeResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<StoryLike, ResultStoryLikeWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryLikeAdminConnection, ResultStoryLikeWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(StoryLikeAdminFilterType))]
        [UseSorting(typeof(StoryLikeAdminSortType))]
        public async Task<StoryLikeAdminConnection> GetStoryLikesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IStoryLikeQueryService service,
            [Service] IStoryLikeResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<StoryLike, ResultStoryLikeWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryLikeAdminConnection, ResultStoryLikeWithRelationsAdminDto>(connection);
        }

        public async Task<ResultStoryLikeWithRelationsAdminDto?> GetStoryLikeByIdAsync(
            string? key,
            [Service] IStoryLikeQueryService service,
            [Service] IStoryLikeResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultStoryLikeWithRelationsAdminDto>(entity);
        }
    }

}

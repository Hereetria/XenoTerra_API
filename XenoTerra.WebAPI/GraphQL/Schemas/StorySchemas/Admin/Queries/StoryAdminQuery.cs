using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.StoryResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class StoryAdminQuery(IMapper mapper, IQueryResolverHelper<Story, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Story, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(StoryAdminFilterType))]
        [UseSorting(typeof(StoryAdminSortType))]
        public async Task<StoryAdminConnection> GetAllStoriesAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryAdminConnection, ResultStoryWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(StoryAdminFilterType))]
        [UseSorting(typeof(StoryAdminSortType))]
        public async Task<StoryAdminConnection> GetStoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryAdminConnection, ResultStoryWithRelationsDto>(connection);
        }

        public async Task<ResultStoryWithRelationsDto?> GetStoryByIdAsync(
            string? key,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultStoryWithRelationsDto>(entity);
        }
    }
}

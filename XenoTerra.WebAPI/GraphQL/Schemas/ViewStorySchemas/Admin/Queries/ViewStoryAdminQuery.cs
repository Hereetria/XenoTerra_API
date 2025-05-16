using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ViewStoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Queries
{
    public class ViewStoryAdminQuery(IMapper mapper, IQueryResolverHelper<ViewStory, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<ViewStory, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ViewStoryAdminFilterType))]
        [UseSorting(typeof(ViewStoryAdminSortType))]
        public async Task<ViewStoryAdminConnection> GetAllViewStorysAsync(
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<ViewStory, ResultViewStoryWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ViewStoryAdminConnection, ResultViewStoryWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ViewStoryAdminFilterType))]
        [UseSorting(typeof(ViewStoryAdminSortType))]
        public async Task<ViewStoryAdminConnection> GetViewStorysByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<ViewStory, ResultViewStoryWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ViewStoryAdminConnection, ResultViewStoryWithRelationsDto>(connection);
        }

        public async Task<ResultViewStoryWithRelationsDto?> GetViewStoryByIdAsync(
            string? key,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultViewStoryWithRelationsDto>(entity);
        }
    }
}
using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ViewStoryResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class ViewStoryAdminQuery(IMapper mapper, IQueryResolverHelper<ViewStory, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<ViewStory, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ViewStoryAdminFilterType))]
        [UseSorting(typeof(ViewStoryAdminSortType))]
        public async Task<ViewStoryAdminConnection> GetAllViewStoriesAsync(
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ViewStory, ResultViewStoryWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ViewStoryAdminConnection, ResultViewStoryWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ViewStoryAdminFilterType))]
        [UseSorting(typeof(ViewStoryAdminSortType))]
        public async Task<ViewStoryAdminConnection> GetViewStoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ViewStory, ResultViewStoryWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ViewStoryAdminConnection, ResultViewStoryWithRelationsAdminDto>(connection);
        }

        public async Task<ResultViewStoryWithRelationsAdminDto?> GetViewStoryByIdAsync(
            string? key,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultViewStoryWithRelationsAdminDto>(entity);
        }
    }
}
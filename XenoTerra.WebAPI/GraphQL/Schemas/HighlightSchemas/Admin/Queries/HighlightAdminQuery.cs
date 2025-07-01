using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.HighlightResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class HighlightAdminQuery(IMapper mapper, IQueryResolverHelper<Highlight, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Highlight, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightAdminFilterType))]
        [UseSorting(typeof(HighlightAdminSortType))]
        public async Task<HighlightAdminConnection> GetAllHighlightsAsync(
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightAdminConnection, ResultHighlightWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightAdminFilterType))]
        [UseSorting(typeof(HighlightAdminSortType))]
        public async Task<HighlightAdminConnection> GetHighlightsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightAdminConnection, ResultHighlightWithRelationsAdminDto>(connection);
        }

        public async Task<ResultHighlightWithRelationsAdminDto?> GetHighlightByIdAsync(
            string? key,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultHighlightWithRelationsAdminDto>(entity);
        }
    }

}

using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.HighlightResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Queries
{
    public class HighlightQuery(IMapper mapper, IQueryResolverHelper<Highlight, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Highlight, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightFilterType))]
        [UseSorting(typeof(HighlightSortType))]
        public async Task<HighlightConnection> GetAllHighlightsAsync(
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightConnection, ResultHighlightWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightFilterType))]
        [UseSorting(typeof(HighlightSortType))]
        public async Task<HighlightConnection> GetHighlightsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightConnection, ResultHighlightWithRelationsDto>(connection);
        }

        public async Task<ResultHighlightWithRelationsDto?> GetHighlightByIdAsync(
            string? key,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultHighlightWithRelationsDto>(entity);
        }
    }

}

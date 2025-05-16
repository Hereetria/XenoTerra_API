using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MediaResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.MediaQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries
{
    public class MediaAdminQuery(IMapper mapper, IQueryResolverHelper<Media, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Media, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(MediaAdminFilterType))]
        [UseSorting(typeof(MediaAdminSortType))]
        public async Task<MediaAdminConnection> GetAllMediasAsync(
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<Media, ResultMediaWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MediaAdminConnection, ResultMediaWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(MediaAdminFilterType))]
        [UseSorting(typeof(MediaAdminSortType))]
        public async Task<MediaAdminConnection> GetMediasByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<Media, ResultMediaWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MediaAdminConnection, ResultMediaWithRelationsDto>(connection);
        }

        public async Task<ResultMediaWithRelationsDto?> GetMediaByIdAsync(
            string? key,
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultMediaWithRelationsDto>(entity);
        }
    }
}

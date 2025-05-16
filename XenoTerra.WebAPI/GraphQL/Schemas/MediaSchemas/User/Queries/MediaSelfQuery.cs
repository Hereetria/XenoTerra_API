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
    public class MediaSelfQuery(IMapper mapper, IQueryResolverHelper<Media, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Media, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(MediaSelfFilterType))]
        [UseSorting(typeof(MediaSelfSortType))]
        public async Task<MediaSelfConnection> GetAllMediasAsync(
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Media, ResultMediaWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MediaSelfConnection, ResultMediaWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(MediaSelfFilterType))]
        [UseSorting(typeof(MediaSelfSortType))]
        public async Task<MediaSelfConnection> GetMediasByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Media, ResultMediaWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MediaSelfConnection, ResultMediaWithRelationsDto>(connection);
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

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
    public class MediaQuery(IMapper mapper, IQueryResolverHelper<Media, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Media, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(MediaFilterType))]
        [UseSorting(typeof(MediaSortType))]
        public async Task<MediaConnection> GetAllMediasAsync(
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Media, ResultMediaWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MediaConnection, ResultMediaWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(MediaFilterType))]
        [UseSorting(typeof(MediaSortType))]
        public async Task<MediaConnection> GetMediasByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Media, ResultMediaWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MediaConnection, ResultMediaWithRelationsDto>(connection);
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

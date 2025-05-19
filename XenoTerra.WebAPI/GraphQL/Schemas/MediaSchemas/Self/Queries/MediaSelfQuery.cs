using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.MediaResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.MediaQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
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
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateMediaAccessFilter(currentUserId);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Media, ResultMediaWithRelationsDto>(
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
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateMediaAccessFilter(currentUserId);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Media, ResultMediaWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MediaSelfConnection, ResultMediaWithRelationsDto>(connection);
        }

        public async Task<ResultMediaWithRelationsDto?> GetMediaByIdAsync(
            string? key,
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateMediaAccessFilter(currentUserId);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultMediaWithRelationsDto>(entity);
        }

        private static Expression<Func<Media, bool>> CreateMediaAccessFilter(Guid currentUserId)
        {
            var userIds = new[] { currentUserId };

            return media => userIds.Contains(media.SenderId) || userIds.Contains(media.ReceiverId);
        }
    }
}

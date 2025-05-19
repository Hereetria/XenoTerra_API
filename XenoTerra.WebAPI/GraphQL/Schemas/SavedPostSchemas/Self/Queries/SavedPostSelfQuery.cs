using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.SavedPostResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.SavedPostQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class SavedPostSelfQuery(IMapper mapper, IQueryResolverHelper<SavedPost, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<SavedPost, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(SavedPostSelfFilterType))]
        [UseSorting(typeof(SavedPostSelfSortType))]
        public async Task<SavedPostSelfConnection> GetAllSavedPostsAsync(
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateSavedPostAccessFilter(currentUserId);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SavedPost, ResultSavedPostWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SavedPostSelfConnection, ResultSavedPostWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(SavedPostSelfFilterType))]
        [UseSorting(typeof(SavedPostSelfSortType))]
        public async Task<SavedPostSelfConnection> GetSavedPostsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateSavedPostAccessFilter(currentUserId);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SavedPost, ResultSavedPostWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SavedPostSelfConnection, ResultSavedPostWithRelationsDto>(connection);
        }

        public async Task<ResultSavedPostWithRelationsDto?> GetSavedPostByIdAsync(
            string? key,
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateSavedPostAccessFilter(currentUserId);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultSavedPostWithRelationsDto>(entity);
        }

        private static Expression<Func<SavedPost, bool>> CreateSavedPostAccessFilter(Guid currentUserId) =>
            savedPost => savedPost.UserId == currentUserId;
    }
}

using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.BlockUserResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class BlockUserSelfQuery(IMapper mapper, IQueryResolverHelper<BlockUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<BlockUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(BlockUserSelfFilterType))]
        [UseSorting(typeof(BlockUserSelfSortType))]
        public async Task<BlockUserSelfConnection> GetAllBlockUsersAsync(
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateBlockUserAccessFilter(currentUserId);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<BlockUser, ResultBlockUserWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<BlockUserSelfConnection, ResultBlockUserWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(BlockUserSelfFilterType))]
        [UseSorting(typeof(BlockUserSelfSortType))]
        public async Task<BlockUserSelfConnection> GetBlockUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateBlockUserAccessFilter(currentUserId);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<BlockUser, ResultBlockUserWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<BlockUserSelfConnection, ResultBlockUserWithRelationsDto>(connection);
        }

        public async Task<ResultBlockUserWithRelationsDto?> GetBlockUserByIdAsync(
            string? key,
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateBlockUserAccessFilter(currentUserId);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultBlockUserWithRelationsDto>(entity);
        }

        private static Expression<Func<BlockUser, bool>> CreateBlockUserAccessFilter(Guid currentUserId) =>
            blockUser => blockUser.BlockingUserId == currentUserId;
        

    }
}

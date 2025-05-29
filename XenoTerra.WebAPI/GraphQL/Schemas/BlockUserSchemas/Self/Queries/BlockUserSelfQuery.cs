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
using Microsoft.AspNetCore.Http;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
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
            var filter = CreateBlockUserAccessFilter(httpContextAccessor);

            var query = service.GetAllQueryable(context, filter);
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

            var filter = CreateBlockUserAccessFilter(httpContextAccessor);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
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

            var filter = CreateBlockUserAccessFilter(httpContextAccessor);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultBlockUserWithRelationsDto>(entity);
        }

        private static Expression<Func<BlockUser, bool>> CreateBlockUserAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<BlockUser, Guid>(
                b => b.BlockingUserId,
                currentUserId
            );
        }
    }
}

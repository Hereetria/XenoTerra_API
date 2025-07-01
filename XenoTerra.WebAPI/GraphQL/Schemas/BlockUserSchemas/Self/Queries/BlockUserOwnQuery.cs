using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.BlockUserResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class BlockUserOwnQuery(IMapper mapper, IQueryResolverHelper<BlockUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<BlockUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(BlockUserOwnFilterType))]
        [UseSorting(typeof(BlockUserOwnSortType))]
        public async Task<BlockUserOwnConnection> GetAllBlockUsersAsync(
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateBlockUserAccessFilter(httpContextAccessor);

            var query = service.GetAllQueryable(context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<BlockUser, ResultBlockUserWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<BlockUserOwnConnection, ResultBlockUserWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(BlockUserOwnFilterType))]
        [UseSorting(typeof(BlockUserOwnSortType))]
        public async Task<BlockUserOwnConnection> GetBlockUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = CreateBlockUserAccessFilter(httpContextAccessor);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<BlockUser, ResultBlockUserWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<BlockUserOwnConnection, ResultBlockUserWithRelationsOwnDto>(connection);
        }

        public async Task<ResultBlockUserWithRelationsOwnDto?> GetBlockUserByIdAsync(
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

            return entity is null ? null : _mapper.Map<ResultBlockUserWithRelationsOwnDto>(entity);
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

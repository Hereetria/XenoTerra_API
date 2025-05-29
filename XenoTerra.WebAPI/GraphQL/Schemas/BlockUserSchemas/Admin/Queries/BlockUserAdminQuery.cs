using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.BlockUserResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class BlockUserAdminQuery(IMapper mapper, IQueryResolverHelper<BlockUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<BlockUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(BlockUserAdminFilterType))]
        [UseSorting(typeof(BlockUserAdminSortType))]
        public async Task<BlockUserAdminConnection> GetAllBlockUsersAsync(
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<BlockUser, ResultBlockUserWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<BlockUserAdminConnection, ResultBlockUserWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(BlockUserAdminFilterType))]
        [UseSorting(typeof(BlockUserAdminSortType))]
        public async Task<BlockUserAdminConnection> GetBlockUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<BlockUser, ResultBlockUserWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<BlockUserAdminConnection, ResultBlockUserWithRelationsDto>(connection);
        }

        public async Task<ResultBlockUserWithRelationsDto?> GetBlockUserByIdAsync(
            string? key,
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultBlockUserWithRelationsDto>(entity);
        }
    }
}

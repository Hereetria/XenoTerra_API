using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.LikeResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.LikeQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class LikeAdminQuery(IMapper mapper, IQueryResolverHelper<Like, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Like, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(LikeAdminFilterType))]
        [UseSorting(typeof(LikeAdminSortType))]
        public async Task<LikeAdminConnection> GetAllLikesAsync(
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Like, ResultLikeWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<LikeAdminConnection, ResultLikeWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(LikeAdminFilterType))]
        [UseSorting(typeof(LikeAdminSortType))]
        public async Task<LikeAdminConnection> GetLikesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Like, ResultLikeWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<LikeAdminConnection, ResultLikeWithRelationsDto>(connection);
        }

        public async Task<ResultLikeWithRelationsDto?> GetLikeByIdAsync(
            string? key,
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultLikeWithRelationsDto>(entity);
        }
    }

}

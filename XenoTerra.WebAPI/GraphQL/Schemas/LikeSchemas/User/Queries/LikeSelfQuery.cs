using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.LikeResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.LikeQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries
{
    public class LikeSelfQuery(IMapper mapper, IQueryResolverHelper<Like, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Like, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(LikeSelfFilterType))]
        [UseSorting(typeof(LikeSelfSortType))]
        public async Task<LikeSelfConnection> GetAllLikesAsync(
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Like, ResultLikeWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<LikeSelfConnection, ResultLikeWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(LikeSelfFilterType))]
        [UseSorting(typeof(LikeSelfSortType))]
        public async Task<LikeSelfConnection> GetLikesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Like, ResultLikeWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<LikeSelfConnection, ResultLikeWithRelationsDto>(connection);
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

            return _mapper.Map<ResultLikeWithRelationsDto>(entity);
        }
    }

}

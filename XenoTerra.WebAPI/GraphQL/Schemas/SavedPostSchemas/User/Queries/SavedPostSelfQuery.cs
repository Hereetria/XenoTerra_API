using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SavedPostResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.SavedPostQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries
{
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
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<SavedPost, ResultSavedPostWithRelationsDto>(
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
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<SavedPost, ResultSavedPostWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SavedPostSelfConnection, ResultSavedPostWithRelationsDto>(connection);
        }

        public async Task<ResultSavedPostWithRelationsDto?> GetSavedPostByIdAsync(
            string? key,
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultSavedPostWithRelationsDto>(entity);
        }
    }
}

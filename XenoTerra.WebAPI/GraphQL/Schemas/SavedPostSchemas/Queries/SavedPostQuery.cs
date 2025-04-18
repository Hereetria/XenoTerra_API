﻿using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostQueries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostQueries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SavedPostResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.SavedPostQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostQueries
{
    public class SavedPostQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<SavedPost, Guid> _queryResolver;

        public SavedPostQuery(IMapper mapper, IQueryResolverHelper<SavedPost, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(SavedPostFilterType))]
        [UseSorting(typeof(SavedPostSortType))]
        public async Task<IEnumerable<ResultSavedPostWithRelationsDto>> GetAllSavedPostsAsync(
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultSavedPostWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(SavedPostFilterType))]
        [UseSorting(typeof(SavedPostSortType))]
        public async Task<IEnumerable<ResultSavedPostWithRelationsDto>> GetSavedPostsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultSavedPostWithRelationsDto>>(entities);
        }

        public async Task<ResultSavedPostWithRelationsDto> GetSavedPostByIdAsync(
            Guid key,
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultSavedPostWithRelationsDto>(entity);
        }
    }
}

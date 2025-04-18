﻿using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.MediaQueries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.MediaQueries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MediaResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.MediaQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.MediaQueries
{
    public class MediaQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Media, Guid> _queryResolver;

        public MediaQuery(IMapper mapper, IQueryResolverHelper<Media, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(MediaFilterType))]
        [UseSorting(typeof(MediaSortType))]
        public async Task<IEnumerable<ResultMediaWithRelationsDto>> GetAllMediaAsync(
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultMediaWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(MediaFilterType))]
        [UseSorting(typeof(MediaSortType))]
        public async Task<IEnumerable<ResultMediaWithRelationsDto>> GetMediaByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultMediaWithRelationsDto>>(entities);
        }

        public async Task<ResultMediaWithRelationsDto> GetMediaByIdAsync(
            Guid key,
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultMediaWithRelationsDto>(entity);
        }
    }
}

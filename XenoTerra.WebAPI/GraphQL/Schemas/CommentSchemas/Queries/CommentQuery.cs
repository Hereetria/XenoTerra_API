using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentService;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.CommentQueries.Filters;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.CommentResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.CommentQueries
{
    public class CommentQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Comment, Guid> _queryResolver;

        public CommentQuery(IMapper mapper, IQueryResolverHelper<Comment, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(CommentFilterType))]
        [UseSorting(typeof(CommentSortType))]
        public async Task<IEnumerable<ResultCommentWithRelationsDto>> GetAllCommentsAsync(
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultCommentWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(CommentFilterType))]
        [UseSorting(typeof(CommentSortType))]
        public async Task<IEnumerable<ResultCommentWithRelationsDto>> GetCommentsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultCommentWithRelationsDto>>(entities);
        }

        public async Task<ResultCommentWithRelationsDto> GetCommentByIdAsync(
            Guid key,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultCommentWithRelationsDto>(entity);
        }
    }
}

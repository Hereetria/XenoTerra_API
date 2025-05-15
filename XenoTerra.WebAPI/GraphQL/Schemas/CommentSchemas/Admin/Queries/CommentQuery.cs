using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.CommentResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries
{
    public class CommentQuery(IMapper mapper, IQueryResolverHelper<Comment, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Comment, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(CommentFilterType))]
        [UseSorting(typeof(CommentSortType))]
        public async Task<CommentConnection> GetAllCommentsAsync(
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Comment, ResultCommentWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentConnection, ResultCommentWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(CommentFilterType))]
        [UseSorting(typeof(CommentSortType))]
        public async Task<CommentConnection> GetCommentsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Comment, ResultCommentWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentConnection, ResultCommentWithRelationsDto>(connection);
        }

        public async Task<ResultCommentWithRelationsDto?> GetCommentByIdAsync(
            string? key,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultCommentWithRelationsDto>(entity);
        }
    }
}

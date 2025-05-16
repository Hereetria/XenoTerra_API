using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserPostTagResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries
{
    public class UserPostTagSelfQuery(IMapper mapper, IQueryResolverHelper<UserPostTag, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<UserPostTag, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserPostTagSelfFilterType))]
        [UseSorting(typeof(UserPostTagSelfSortType))]
        public async Task<UserPostTagSelfConnection> GetAllUserPostTagsAsync(
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<UserPostTag, ResultUserPostTagWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPostTagSelfConnection, ResultUserPostTagWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserPostTagSelfFilterType))]
        [UseSorting(typeof(UserPostTagSelfSortType))]
        public async Task<UserPostTagSelfConnection> GetUserPostTagsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<UserPostTag, ResultUserPostTagWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPostTagSelfConnection, ResultUserPostTagWithRelationsDto>(connection);
        }

        public async Task<ResultUserPostTagWithRelationsDto?> GetUserPostTagByIdAsync(
            string? key,
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultUserPostTagWithRelationsDto>(entity);
        }
    }
}

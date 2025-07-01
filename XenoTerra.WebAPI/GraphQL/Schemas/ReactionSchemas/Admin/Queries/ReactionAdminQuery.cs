using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ReactionResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class ReactionAdminQuery(IMapper mapper, IQueryResolverHelper<Reaction, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Reaction, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ReactionAdminFilterType))]
        [UseSorting(typeof(ReactionAdminSortType))]
        public async Task<ReactionAdminConnection> GetAllReactionsAsync(
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Reaction, ResultReactionWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReactionAdminConnection, ResultReactionWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ReactionAdminFilterType))]
        [UseSorting(typeof(ReactionAdminSortType))]
        public async Task<ReactionAdminConnection> GetReactionsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Reaction, ResultReactionWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReactionAdminConnection, ResultReactionWithRelationsAdminDto>(connection);
        }

        public async Task<ResultReactionWithRelationsAdminDto?> GetReactionByIdAsync(
            string? key,
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultReactionWithRelationsAdminDto>(entity);
        }
    }
}

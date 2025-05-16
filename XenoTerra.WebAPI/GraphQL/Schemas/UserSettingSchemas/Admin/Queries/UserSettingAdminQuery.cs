using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Queries.Filters;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserSettingResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserSettingQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Queries
{
    public class UserSettingAdminQuery(IMapper mapper, IQueryResolverHelper<UserSetting, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<UserSetting, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserSettingAdminFilterType))]
        [UseSorting(typeof(UserSettingAdminSortType))]
        public async Task<UserSettingAdminConnection> GetAllUserSettingsAsync(
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<UserSetting, ResultUserSettingWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserSettingAdminConnection, ResultUserSettingWithRelationsDto>(connection);
        }



        [UseCustomPaging]
        [UseFiltering(typeof(UserSettingAdminFilterType))]
        [UseSorting(typeof(UserSettingAdminSortType))]
        public async Task<UserSettingAdminConnection> GetUserSettingsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapAdminConnection<UserSetting, ResultUserSettingWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserSettingAdminConnection, ResultUserSettingWithRelationsDto>(connection);
        }

        public async Task<ResultUserSettingWithRelationsDto?> GetUserSettingByIdAsync(
            string? key,
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultUserSettingWithRelationsDto>(entity);
        }
    }
}

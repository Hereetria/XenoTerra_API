using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingService;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserSettingResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserSettingResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserSettingQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.UserSettingQueries
{
    public class UserSettingQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<UserSetting, Guid> _queryResolver;

        public UserSettingQuery(IMapper mapper, IQueryResolverHelper<UserSetting, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(UserSettingFilterType))]
        [UseSorting(typeof(UserSettingSortType))]
        public async Task<IEnumerable<ResultUserSettingWithRelationsDto>> GetAllUserSettingsAsync(
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultUserSettingWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(UserSettingFilterType))]
        [UseSorting(typeof(UserSettingSortType))]
        public async Task<IEnumerable<ResultUserSettingWithRelationsDto>> GetUserSettingsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultUserSettingWithRelationsDto>>(entities);
        }

        public async Task<ResultUserSettingWithRelationsDto> GetUserSettingByIdAsync(
            Guid key,
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultUserSettingWithRelationsDto>(entity);
        }
    }
}

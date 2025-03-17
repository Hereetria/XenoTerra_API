using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingService;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserSettingResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserSettingQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.UserSettingQueries
{
    public class UserSettingQuery
    {
        private readonly IMapper _mapper;

        public UserSettingQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultUserSettingWithRelationsDto>> GetAllUserSettingsAsync(
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            IResolverContext context)
        {
            var userSettings = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(userSettings, context);
            var userSettingDtos = _mapper.Map<List<ResultUserSettingWithRelationsDto>>(userSettings);
            return userSettingDtos;
        }

        public async Task<IEnumerable<ResultUserSettingWithRelationsDto>> GetUserSettingsByIdsAsync(
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var userSettings = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(userSettings, context);
            var userSettingDtos = _mapper.Map<List<ResultUserSettingWithRelationsDto>>(userSettings);
            return userSettingDtos;
        }

        public async Task<ResultUserSettingWithRelationsDto> GetUserSettingByIdAsync(
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var userSetting = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(userSetting, context);
            var userSettingDto = _mapper.Map<ResultUserSettingWithRelationsDto>(userSetting);
            return userSettingDto;
        }
    }

}

using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingService;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.UserSettingQueries
{
    public class UserSettingQuery
    {
        public async Task<IEnumerable<ResultUserSettingWithRelationsDto>> GetAllUserSettingsAsync(
            [Service] IUserSettingReadService userSettingReadService,
            [Service] UserSettingResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = userSettingReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<UserSetting>().AsQueryable();

            var userSettings = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(userSettings, context);

            return mapper.Map<List<ResultUserSettingWithRelationsDto>>(userSettings);
        }

        public async Task<IEnumerable<ResultUserSettingWithRelationsDto>> GetUserSettingsByIdsAsync(
            [Service] IUserSettingReadService userSettingReadService,
            [Service] UserSettingResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = userSettingReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<UserSetting>().AsQueryable();

            var userSettings = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(userSettings, context);

            return mapper.Map<List<ResultUserSettingWithRelationsDto>>(userSettings);
        }

        public async Task<ResultUserSettingWithRelationsDto> GetUserSettingByIdAsync(
            [Service] IUserSettingReadService userSettingReadService,
            [Service] UserSettingResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = userSettingReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<UserSetting>().AsQueryable();

            var userSetting = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"UserSetting with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(userSetting, context);

            return mapper.Map<ResultUserSettingWithRelationsDto>(userSetting);
        }

    }
}

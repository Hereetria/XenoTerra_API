using AutoMapper;
using HotChocolate;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowService;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.FollowQueries
{
    public class FollowQuery
    {
        public async Task<IEnumerable<ResultFollowWithRelationsDto>> GetAllFollowsAsync(
            [Service] IFollowReadService followReadService,
            [Service] FollowResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = followReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Follow>().AsQueryable();

            var follows = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(follows, context);

            return mapper.Map<List<ResultFollowWithRelationsDto>>(follows);
        }

        public async Task<IEnumerable<ResultFollowWithRelationsDto>> GetFollowsByIdsAsync(
            [Service] IFollowReadService followReadService,
            [Service] FollowResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = followReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Follow>().AsQueryable();

            var follows = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(follows, context);

            return mapper.Map<List<ResultFollowWithRelationsDto>>(follows);
        }

        public async Task<ResultFollowWithRelationsDto> GetFollowByIdAsync(
            [Service] IFollowReadService followReadService,
            [Service] FollowResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = followReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Follow>().AsQueryable();

            var follow = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Follow with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(follow, context);

            return mapper.Map<ResultFollowWithRelationsDto>(follow);
        }

    }
}

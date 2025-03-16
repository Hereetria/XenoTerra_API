using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagService;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.UserPostTagQueries
{
    public class UserUserPostTagQuery
    {
        public async Task<IEnumerable<ResultUserPostTagWithRelationsDto>> GetAllUserPostTagsAsync(
            [Service] IUserPostTagReadService userPostTagReadService,
            [Service] UserPostTagResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = UserPostTagReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<UserPostTag>().AsQueryable();

            var UserPostTags = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(UserPostTags, context);

            return mapper.Map<List<ResultUserPostTagWithRelationsDto>>(UserPostTags);
        }

        public async Task<IEnumerable<ResultUserPostTagWithRelationsDto>> GetUserPostTagsByIdsAsync(
            [Service] IUserPostTagReadService UserPostTagReadService,
            [Service] UserPostTagResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = UserPostTagReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<UserPostTag>().AsQueryable();

            var UserPostTags = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(UserPostTags, context);

            return mapper.Map<List<ResultUserPostTagWithRelationsDto>>(UserPostTags);
        }

        public async Task<ResultUserPostTagWithRelationsDto> GetUserPostTagByIdAsync(
            [Service] IUserPostTagReadService UserPostTagReadService,
            [Service] UserPostTagResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = UserPostTagReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<UserPostTag>().AsQueryable();

            var UserPostTag = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"UserPostTag with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(UserPostTag, context);

            return mapper.Map<ResultUserPostTagWithRelationsDto>(UserPostTag);
        }

    }
}

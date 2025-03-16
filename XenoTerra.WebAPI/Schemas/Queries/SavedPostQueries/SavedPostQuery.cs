using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostService;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.SavedPostQueries
{
    public class SavedPostQuery
    {
        public async Task<IEnumerable<ResultSavedPostWithRelationsDto>> GetAllSavedPostsAsync(
            [Service] ISavedPostReadService savedPostReadService,
            [Service] SavedPostResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = savedPostReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<SavedPost>().AsQueryable();

            var savedPosts = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(savedPosts, context);

            return mapper.Map<List<ResultSavedPostWithRelationsDto>>(savedPosts);
        }

        public async Task<IEnumerable<ResultSavedPostWithRelationsDto>> GetSavedPostsByIdsAsync(
            [Service] ISavedPostReadService savedPostReadService,
            [Service] SavedPostResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = savedPostReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<SavedPost>().AsQueryable();

            var savedPosts = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(savedPosts, context);

            return mapper.Map<List<ResultSavedPostWithRelationsDto>>(savedPosts);
        }

        public async Task<ResultSavedPostWithRelationsDto> GetSavedPostByIdAsync(
            [Service] ISavedPostReadService savedPostReadService,
            [Service] SavedPostResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = savedPostReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<SavedPost>().AsQueryable();

            var savedPost = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"SavedPost with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(savedPost, context);

            return mapper.Map<ResultSavedPostWithRelationsDto>(savedPost);
        }

    }
}

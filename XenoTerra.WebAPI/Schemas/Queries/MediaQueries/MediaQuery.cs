using AutoMapper;
using HotChocolate;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.MediaService;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.MediaQueries
{
    public class MediaQuery
    {
        public async Task<IEnumerable<ResultMediaWithRelationsDto>> GetAllMediaAsync(
            [Service] IMediaReadService mediaReadService,
            [Service] MediaResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = mediaReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Media>().AsQueryable();

            var media = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(media, context);

            return mapper.Map<List<ResultMediaWithRelationsDto>>(media);
        }

        public async Task<IEnumerable<ResultMediaWithRelationsDto>> GetMediaByIdsAsync(
            [Service] IMediaReadService mediaReadService,
            [Service] MediaResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = mediaReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Media>().AsQueryable();

            var media = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(media, context);

            return mapper.Map<List<ResultMediaWithRelationsDto>>(media);
        }

        public async Task<ResultMediaWithRelationsDto> GetMediaByIdAsync(
            [Service] IMediaReadService mediaReadService,
            [Service] MediaResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = mediaReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Media>().AsQueryable();

            var media = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Media with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(media, context);

            return mapper.Map<ResultMediaWithRelationsDto>(media);
        }

    }
}

using AutoMapper;
using HotChocolate;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.MediaService;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MediaResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.MediaQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.MediaQueries
{
    public class MediaQuery
    {
        private readonly IMapper _mapper;

        public MediaQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultMediaWithRelationsDto>> GetAllMediaAsync(
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IResolverContext context)
        {
            var media = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(media, context);
            var mediaDtos = _mapper.Map<List<ResultMediaWithRelationsDto>>(media);
            return mediaDtos;
        }

        public async Task<IEnumerable<ResultMediaWithRelationsDto>> GetMediaByIdsAsync(
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var media = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(media, context);
            var mediaDtos = _mapper.Map<List<ResultMediaWithRelationsDto>>(media);
            return mediaDtos;
        }

        public async Task<ResultMediaWithRelationsDto> GetMediaByIdAsync(
            [Service] IMediaQueryService service,
            [Service] IMediaResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var media = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(media, context);
            var mediaDto = _mapper.Map<ResultMediaWithRelationsDto>(media);
            return mediaDto;
        }
    }

}

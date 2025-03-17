using AutoMapper;
using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.HighlightService;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.HighlightResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.HighlightQueries
{
    public class HighlightQuery
    {
        private readonly IMapper _mapper;

        public HighlightQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultHighlightWithRelationsDto>> GetAllHighlightsAsync(
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var highlights = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(highlights, context);
            var highlightDtos = _mapper.Map<List<ResultHighlightWithRelationsDto>>(highlights);
            return highlightDtos;
        }

        public async Task<IEnumerable<ResultHighlightWithRelationsDto>> GetHighlightsByIdsAsync(
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var highlights = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(highlights, context);
            var highlightDtos = _mapper.Map<List<ResultHighlightWithRelationsDto>>(highlights);
            return highlightDtos;
        }

        public async Task<ResultHighlightWithRelationsDto> GetHighlightByIdAsync(
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var highlight = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(highlight, context);
            var highlightDto = _mapper.Map<ResultHighlightWithRelationsDto>(highlight);
            return highlightDto;
        }
    }

}

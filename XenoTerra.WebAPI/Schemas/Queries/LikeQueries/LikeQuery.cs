using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.LikeService;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.LikeResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.LikeQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.LikeQueries
{
    public class LikeQuery
    {
        private readonly IMapper _mapper;

        public LikeQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultLikeWithRelationsDto>> GetAllLikesAsync(
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IResolverContext context)
        {
            var likes = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(likes, context);
            var likeDtos = _mapper.Map<List<ResultLikeWithRelationsDto>>(likes);
            return likeDtos;
        }

        public async Task<IEnumerable<ResultLikeWithRelationsDto>> GetLikesByIdsAsync(
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var likes = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(likes, context);
            var likeDtos = _mapper.Map<List<ResultLikeWithRelationsDto>>(likes);
            return likeDtos;
        }

        public async Task<ResultLikeWithRelationsDto> GetLikeByIdAsync(
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var like = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(like, context);
            var likeDto = _mapper.Map<ResultLikeWithRelationsDto>(like);
            return likeDto;
        }
    }

}

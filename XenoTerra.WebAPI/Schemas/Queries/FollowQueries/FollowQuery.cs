using AutoMapper;
using HotChocolate;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowService;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.FollowResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.FollowQueries
{
    public class FollowQuery
    {
        private readonly IMapper _mapper;

        public FollowQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultFollowWithRelationsDto>> GetAllFollowsAsync(
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var follows = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(follows, context);
            var followDtos = _mapper.Map<List<ResultFollowWithRelationsDto>>(follows);
            return followDtos;
        }

        public async Task<IEnumerable<ResultFollowWithRelationsDto>> GetFollowsByIdsAsync(
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var follows = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(follows, context);
            var followDtos = _mapper.Map<List<ResultFollowWithRelationsDto>>(follows);
            return followDtos;
        }

        public async Task<ResultFollowWithRelationsDto> GetFollowByIdAsync(
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var follow = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(follow, context);
            var followDto = _mapper.Map<ResultFollowWithRelationsDto>(follow);
            return followDto;
        }
    }

}

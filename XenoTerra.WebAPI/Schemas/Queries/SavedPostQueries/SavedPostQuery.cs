using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostService;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SavedPostResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.SavedPostQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.SavedPostQueries
{
    public class SavedPostQuery
    {
        private readonly IMapper _mapper;

        public SavedPostQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultSavedPostWithRelationsDto>> GetAllSavedPostsAsync(
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            IResolverContext context)
        {
            var savedPosts = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(savedPosts, context);
            var savedPostDtos = _mapper.Map<List<ResultSavedPostWithRelationsDto>>(savedPosts);
            return savedPostDtos;
        }

        public async Task<IEnumerable<ResultSavedPostWithRelationsDto>> GetSavedPostsByIdsAsync(
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var savedPosts = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(savedPosts, context);
            var savedPostDtos = _mapper.Map<List<ResultSavedPostWithRelationsDto>>(savedPosts);
            return savedPostDtos;
        }

        public async Task<ResultSavedPostWithRelationsDto> GetSavedPostByIdAsync(
            [Service] ISavedPostQueryService service,
            [Service] ISavedPostResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var savedPost = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(savedPost, context);
            var savedPostDto = _mapper.Map<ResultSavedPostWithRelationsDto>(savedPost);
            return savedPostDto;
        }
    }

}

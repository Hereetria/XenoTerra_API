using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostService;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.PostResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.PostQueries
{
    public class PostQuery
    {
        private readonly IMapper _mapper;

        public PostQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultPostWithRelationsDto>> GetAllPostsAsync(
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IResolverContext context)
        {
            var posts = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(posts, context);
            var postDtos = _mapper.Map<List<ResultPostWithRelationsDto>>(posts);
            return postDtos;
        }

        public async Task<IEnumerable<ResultPostWithRelationsDto>> GetPostsByIdsAsync(
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var posts = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(posts, context);
            var postDtos = _mapper.Map<List<ResultPostWithRelationsDto>>(posts);
            return postDtos;
        }

        public async Task<ResultPostWithRelationsDto> GetPostByIdAsync(
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var post = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(post, context);
            var postDto = _mapper.Map<ResultPostWithRelationsDto>(post);
            return postDto;
        }
    }

}

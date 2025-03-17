using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentService;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.CommentResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.CommentQueries
{
    public class CommentQuery
    {
        private readonly IMapper _mapper;

        public CommentQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultCommentWithRelationsDto>> GetAllCommentsAsync(
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var comments = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(comments, context);
            var commentDtos = _mapper.Map<List<ResultCommentWithRelationsDto>>(comments);
            return commentDtos;
        }

        public async Task<IEnumerable<ResultCommentWithRelationsDto>> GetCommentsByIdsAsync(
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var comments = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(comments, context);
            var commentDtos = _mapper.Map<List<ResultCommentWithRelationsDto>>(comments);
            return commentDtos;
        }

        public async Task<ResultCommentWithRelationsDto> GetCommentByIdAsync(
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var comment = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(comment, context);
            var commentDto = _mapper.Map<ResultCommentWithRelationsDto>(comment);
            return commentDto;
        }
    }

}

using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentService;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.CommentQueries
{
    public class CommentQuery
    {
        public async Task<IEnumerable<ResultCommentWithRelationsDto>> GetAllCommentsAsync(
            [Service] ICommentReadService commentReadService,
            [Service] CommentResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = commentReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Comment>().AsQueryable();

            var comments = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(comments, context);

            return mapper.Map<List<ResultCommentWithRelationsDto>>(comments);
        }

        public async Task<IEnumerable<ResultCommentWithRelationsDto>> GetCommentsByIdsAsync(
            [Service] ICommentReadService commentReadService,
            [Service] CommentResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = commentReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Comment>().AsQueryable();

            var comments = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(comments, context);

            return mapper.Map<List<ResultCommentWithRelationsDto>>(comments);
        }

        public async Task<ResultCommentWithRelationsDto> GetCommentByIdAsync(
            [Service] ICommentReadService commentReadService,
            [Service] CommentResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = commentReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Comment>().AsQueryable();

            var comment = await query.FirstOrDefaultAsync()
                ?? throw new System.Collections.Generic.KeyNotFoundException($"Comment with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(comment, context);

            return mapper.Map<ResultCommentWithRelationsDto>(comment);
        }

    }
}

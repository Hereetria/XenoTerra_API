using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.ReportCommentQueries
{
    public class ReportCommentQuery
    {
        public async Task<IEnumerable<ResultReportCommentWithRelationsDto>> GetAllReportCommentsAsync(
            [Service] IReportCommentReadService reportCommentReadService,
            [Service] ReportCommentResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = reportCommentReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<ReportComment>().AsQueryable();

            var reportComments = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(reportComments, context);

            return mapper.Map<List<ResultReportCommentWithRelationsDto>>(reportComments);
        }

        public async Task<IEnumerable<ResultReportCommentWithRelationsDto>> GetReportCommentsByIdsAsync(
            [Service] IReportCommentReadService reportCommentReadService,
            [Service] ReportCommentResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = reportCommentReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<ReportComment>().AsQueryable();

            var reportComments = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(reportComments, context);

            return mapper.Map<List<ResultReportCommentWithRelationsDto>>(reportComments);
        }

        public async Task<ResultReportCommentWithRelationsDto> GetReportCommentByIdAsync(
            [Service] IReportCommentReadService reportCommentReadService,
            [Service] ReportCommentResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = reportCommentReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<ReportComment>().AsQueryable();

            var reportComment = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"ReportComment with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(reportComment, context);

            return mapper.Map<ResultReportCommentWithRelationsDto>(reportComment);
        }

    }

}

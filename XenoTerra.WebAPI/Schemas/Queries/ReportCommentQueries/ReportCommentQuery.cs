using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReportCommentResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReportCommentQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.ReportCommentQueries
{
    public class ReportCommentQuery
    {
        private readonly IMapper _mapper;

        public ReportCommentQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultReportCommentWithRelationsDto>> GetAllReportCommentsAsync(
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            IResolverContext context)
        {
            var reportComments = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(reportComments, context);
            var reportCommentDtos = _mapper.Map<List<ResultReportCommentWithRelationsDto>>(reportComments);
            return reportCommentDtos;
        }

        public async Task<IEnumerable<ResultReportCommentWithRelationsDto>> GetReportCommentsByIdsAsync(
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var reportComments = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(reportComments, context);
            var reportCommentDtos = _mapper.Map<List<ResultReportCommentWithRelationsDto>>(reportComments);
            return reportCommentDtos;
        }

        public async Task<ResultReportCommentWithRelationsDto> GetReportCommentByIdAsync(
            [Service] IReportCommentQueryService service,
            [Service] IReportCommentResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var reportComment = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(reportComment, context);
            var reportCommentDto = _mapper.Map<ResultReportCommentWithRelationsDto>(reportComment);
            return reportCommentDto;
        }
    }


}

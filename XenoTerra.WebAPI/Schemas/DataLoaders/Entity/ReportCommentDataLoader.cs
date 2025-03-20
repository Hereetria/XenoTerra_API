using AutoMapper;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class ReportCommentDataLoader : EntityDataLoader<ReportComment, ResultReportCommentDto, Guid>
    {
        public ReportCommentDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, IMapper mapper, AppDbContext dbContext)
            : base(batchScheduler, options, mapper, dbContext)
        {
        }
    }

}

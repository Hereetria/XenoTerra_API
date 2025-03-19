using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.SavedPostQueryServices
{
    public class SavedPostQueryService : QueryService<SavedPost, ResultSavedPostWithRelationsDto, Guid>, ISavedPostQueryService
    {
        public SavedPostQueryService(IReadService<SavedPost, ResultSavedPostWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper)
        {
        }
    }
}

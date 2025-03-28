using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.SavedPostQueryServices
{
    public class SavedPostQueryService : QueryService<SavedPost, Guid>, ISavedPostQueryService
    {
        public SavedPostQueryService(IReadService<SavedPost, Guid> readService)
            : base(readService)
        {
        }
    }
}

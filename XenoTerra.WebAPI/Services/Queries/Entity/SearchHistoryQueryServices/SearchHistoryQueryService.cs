using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices
{
    public class SearchHistoryQueryService : QueryService<SearchHistory, Guid>, ISearchHistoryQueryService
    {
        public SearchHistoryQueryService(IReadService<SearchHistory, Guid> readService)
            : base(readService)
        {
        }
    }
}

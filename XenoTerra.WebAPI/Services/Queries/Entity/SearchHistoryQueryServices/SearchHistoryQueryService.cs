using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices
{
    public class SearchHistoryQueryService : QueryService<SearchHistory, Guid>, ISearchHistoryQueryService
    {
        public SearchHistoryQueryService(IReadService<SearchHistory, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}

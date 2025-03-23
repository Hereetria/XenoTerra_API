using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryUserQueryServices
{
    public class SearchHistoryUserQueryService : QueryService<SearchHistoryUser, Guid>, ISearchHistoryUserQueryService
    {
        public SearchHistoryUserQueryService(IReadService<SearchHistoryUser, Guid> readService)
            : base(readService) { }
    }

}

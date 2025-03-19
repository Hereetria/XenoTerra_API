using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryUserQueryServices
{
    public class SearchHistoryUserQueryService : QueryService<SearchHistoryUser, ResultSearchHistoryUserWithRelationsDto, Guid>, ISearchHistoryUserQueryService
    {
        public SearchHistoryUserQueryService(IReadService<SearchHistoryUser, ResultSearchHistoryUserWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }

}

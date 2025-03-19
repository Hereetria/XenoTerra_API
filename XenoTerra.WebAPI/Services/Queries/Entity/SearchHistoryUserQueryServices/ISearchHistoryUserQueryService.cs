using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryUserQueryServices
{
    public interface ISearchHistoryUserQueryService : IQueryService<SearchHistoryUser, ResultSearchHistoryUserWithRelationsDto, Guid> { }

}

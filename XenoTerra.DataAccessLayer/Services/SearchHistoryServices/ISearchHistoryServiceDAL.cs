
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.SearchHistoryServices
{
    
    public interface ISearchHistoryServiceDAL : IGenericRepositoryDAL<SearchHistory, ResultSearchHistoryDto, ResultSearchHistoryWithRelationsDto, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>

    {

    }
}
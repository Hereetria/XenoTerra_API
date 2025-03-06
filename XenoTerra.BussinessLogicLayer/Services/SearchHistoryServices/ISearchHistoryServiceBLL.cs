
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.SearchHistoryServices
{
        public interface ISearchHistoryServiceBLL : IGenericRepositoryBLL<SearchHistory, ResultSearchHistoryDto, ResultSearchHistoryWithRelationsDto, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>
    {

    }
}
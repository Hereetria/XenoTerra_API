
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.SearchHistoryServices
{
        public interface ISearchHistoryServiceBLL : IGenericRepositoryBLL<SearchHistory, ResultSearchHistoryDto, ResultSearchHistoryByIdDto, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>
    {

    }
}
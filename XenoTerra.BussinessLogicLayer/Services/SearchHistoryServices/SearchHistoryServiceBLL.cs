
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.SearchHistoryServices
{
     public class SearchHistoryServiceBLL : GenericRepositoryBLL<SearchHistory, ResultSearchHistoryDto, ResultSearchHistoryByIdDto, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>, ISearchHistoryServiceBLL
    {
        public SearchHistoryServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}
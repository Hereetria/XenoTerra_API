
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryUserServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.SearchHistoryUserServices
{
     public class SearchHistoryUserServiceBLL : GenericRepositoryBLL<SearchHistoryUser, ResultSearchHistoryUserDto, ResultSearchHistoryUserByIdDto, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>, ISearchHistoryUserServiceBLL
    {
        public SearchHistoryUserServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}
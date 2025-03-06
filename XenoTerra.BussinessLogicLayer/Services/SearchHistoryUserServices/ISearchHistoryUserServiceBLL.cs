
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.SearchHistoryUserServices
{
        public interface ISearchHistoryUserServiceBLL : IGenericRepositoryBLL<SearchHistoryUser, ResultSearchHistoryUserDto, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>
    {

    }
}
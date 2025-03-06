
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.SearchHistoryUserServices
{
    
    public interface ISearchHistoryUserServiceDAL : IGenericRepositoryDAL<SearchHistoryUser, ResultSearchHistoryUserDto, ResultSearchHistoryUserWithRelationsDto, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>

    {

    }
}
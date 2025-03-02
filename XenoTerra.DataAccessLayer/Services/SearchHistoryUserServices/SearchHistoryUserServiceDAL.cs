

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.SearchHistoryUserServices
{
    
    public class SearchHistoryUserServiceDAL : GenericRepositoryDAL<SearchHistoryUser, ResultSearchHistoryUserDto, ResultSearchHistoryUserByIdDto, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>, ISearchHistoryUserServiceDAL

    {

        public SearchHistoryUserServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
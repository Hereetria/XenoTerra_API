

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.SearchHistoryServices
{
    
    public class SearchHistoryServiceDAL : GenericRepositoryDAL<SearchHistory, ResultSearchHistoryDto, ResultSearchHistoryByIdDto, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>, ISearchHistoryServiceDAL

    {

        public SearchHistoryServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
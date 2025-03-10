using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserService
{
    public class SearchHistoryUserReadService : ReadService<SearchHistoryUser, ResultSearchHistoryUserWithRelationsDto, Guid>, ISearchHistoryUserReadService
    {
        public SearchHistoryUserReadService(IReadRepository<SearchHistoryUser, Guid> repository, IMapper mapper, SelectorExpressionProvider<SearchHistoryUser, ResultSearchHistoryUserWithRelationsDto> selectorExpressionProvider) : base(repository, mapper, selectorExpressionProvider)
        {
        }
    }
}

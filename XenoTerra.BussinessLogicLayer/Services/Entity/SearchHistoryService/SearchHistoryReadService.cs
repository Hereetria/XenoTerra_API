using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService
{

    public class SearchHistoryReadService : ReadService<SearchHistory, ResultSearchHistoryWithRelationsDto, Guid>, ISearchHistoryReadService
    {
        public SearchHistoryReadService(IReadRepository<SearchHistory, ResultSearchHistoryWithRelationsDto, Guid> repository)
            : base(repository) { }
    }
}

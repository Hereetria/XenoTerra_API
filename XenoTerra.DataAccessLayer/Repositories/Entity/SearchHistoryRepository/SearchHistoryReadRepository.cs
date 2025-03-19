using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryRepository
{
    public class SearchHistoryReadRepository : ReadRepository<SearchHistory, ResultSearchHistoryWithRelationsDto, Guid>, ISearchHistoryReadRepository
    {
        public SearchHistoryReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}

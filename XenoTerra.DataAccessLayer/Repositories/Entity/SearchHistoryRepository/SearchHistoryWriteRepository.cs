using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryRepository
{

    public class SearchHistoryWriteRepository : WriteRepository<SearchHistory, Guid>, ISearchHistoryWriteRepository
    {
        public SearchHistoryWriteRepository(AppDbContext context) : base(context) { }
    }
}

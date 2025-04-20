using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryRepository
{
    public interface ISearchHistoryWriteRepository : IWriteRepository<SearchHistory, Guid>
    {
    }
}

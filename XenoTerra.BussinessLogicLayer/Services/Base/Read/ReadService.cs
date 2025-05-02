using Microsoft.EntityFrameworkCore.Metadata.Internal;
using XenoTerra.BussinessLogicLayer.Helpers;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.BussinessLogicLayer.Services.Base.Read
{
    public class ReadService<TEntity, TKey>(IReadRepository<TEntity, TKey> readRepository) : IReadService<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly IReadRepository<TEntity, TKey> _readRepository = readRepository;

        public IQueryable<TEntity> GetRawQueryable()
        {
            return ServiceExceptionHandler.ExecuteReadSafely(() => _readRepository.GetRawQueryable());
        }

        public IQueryable<TEntity> FetchAllQueryable(IQueryable<TEntity> query, IEnumerable<string> selectedFields)
        {
            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields, "Field list cannot be null.", "At least one field must be selected.");
            return ServiceExceptionHandler.ExecuteReadSafely(() => _readRepository.GetAllQueryable(query, selectedFields));
        }

        public IQueryable<TEntity> FetchByIdQueryable(IQueryable<TEntity> query, TKey key, IEnumerable<string> selectedFields)
        {
            ArgumentGuard.EnsureValidKey(key);
            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields, "Field list cannot be null.", "At least one field must be selected.");

            return ServiceExceptionHandler.ExecuteReadSafely(() => _readRepository.GetByIdQueryable(query, key, selectedFields));
        }

        public IQueryable<TEntity> FetchByIdsQueryable(IQueryable<TEntity> query, IEnumerable<TKey> keys, IEnumerable<string> selectedFields)
        {
            ArgumentGuard.EnsureNotNullOrEmpty(keys);
            ArgumentGuard.EnsureNotNullOrEmpty(selectedFields, "Field list cannot be null.", "At least one field must be selected.");

            return ServiceExceptionHandler.ExecuteReadSafely(() => _readRepository.GetByIdsQueryable(query, keys, selectedFields));
        }
    }
}

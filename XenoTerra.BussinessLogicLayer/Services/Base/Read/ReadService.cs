using XenoTerra.DataAccessLayer.Repositories.Base.Read;

namespace XenoTerra.BussinessLogicLayer.Services.Base.Read
{
    public class ReadService<TEntity, TKey>(IReadRepository<TEntity, TKey> readRepository) : IReadService<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        protected readonly IReadRepository<TEntity, TKey> _readRepository = readRepository
            ?? throw new ArgumentNullException(nameof(readRepository), $"{nameof(readRepository)} cannot be null");

        public IQueryable<TEntity> FetchAllQueryable(IEnumerable<string> selectedProperties)
        {
            var query = _readRepository.GetAllQueryable(selectedProperties);
            return query;
        }

        public IQueryable<TEntity> FetchByIdQueryable(TKey key, IEnumerable<string> selectedProperties)
        {
            if (key is null || EqualityComparer<TKey>.Default.Equals(key, default) && typeof(TKey) == typeof(Guid))
                throw new ArgumentException("The key cannot be null or an empty GUID.", nameof(key));

            var query = _readRepository.GetByIdQueryable(key, selectedProperties);
            return query;
        }

        public IQueryable<TEntity> FetchByIdsQueryable(IEnumerable<TKey> keys, IEnumerable<string> selectedProperties)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentException("The keys collection cannot be null or empty.", nameof(keys));


            var query = _readRepository.GetByIdsQueryable(keys, selectedProperties);
            return query;
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.BussinessLogicLayer.Services.Generic.Read
{
    public class ReadService<TEntity, TDtoResult, TKey> : IReadService<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        protected readonly IReadRepository<TEntity, TDtoResult, TKey> _readRepository;

        public ReadService(IReadRepository<TEntity, TDtoResult, TKey> readRepository)
        {
            _readRepository = readRepository;
        }
        
        public IQueryable<TDtoResult> FetchAllQueryable(IEnumerable<string> selectedProperties)
        {
            var query = _readRepository.GetAllQueryable(selectedProperties);
            return query;
        }

        public IQueryable<TDtoResult> FetchByIdQueryable(TKey key, IEnumerable<string> selectedProperties)
        {
            if (key is null || (EqualityComparer<TKey>.Default.Equals(key, default) && typeof(TKey) == typeof(Guid)))
                throw new ArgumentException("The key cannot be null or an empty GUID.", nameof(key));

            var query = _readRepository.GetByIdQueryable(key, selectedProperties);
            return query;
        }

        public IQueryable<TDtoResult> FetchByIdsQueryable(IEnumerable<TKey> keys, IEnumerable<string> selectedProperties)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");


            var query = _readRepository.GetByIdsQueryable(keys, selectedProperties);
            return query;
        }
    }
}

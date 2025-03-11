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
    public class ReadService<TEntity, TKey> : IReadService<TEntity, TKey>
        where TEntity : class
    {
        private readonly IReadRepository<TEntity, TKey> _repository;

        public ReadService(IReadRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }
        
        public IQueryable<TEntity> FetchAllQueryable(IEnumerable<string> selectedProperties)
        {

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_repository.GetDbContext(), selectedProperties);
            return _repository.GetAllQueryable()
                .Select(selector);
        }

        public IQueryable<TEntity> FetchByIdQueryable(TKey key, IEnumerable<string> selectedProperties)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The key cannot be null.");

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_repository.GetDbContext(), selectedProperties);

            return _repository.GetByIdQueryable(key)
                        .Select(selector);
        }

        public IQueryable<TEntity> FetchByIdsQueryable(IEnumerable<TKey> keys, IEnumerable<string> selectedProperties)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<TEntity>(_repository.GetDbContext(), selectedProperties);

            return _repository.GetByIdsQueryable(keys)
                .Select(selector);
        }
    }
}

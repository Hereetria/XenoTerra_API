using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.BussinessLogicLayer.Services.Generic.Read
{
    public class ReadService<TEntity, TResultDto, TKey> : IReadService<TEntity, TResultDto, TKey>
        where TEntity : class
        where TResultDto : class, new()
    {
        private readonly IReadRepository<TEntity, TKey> _repository;
        private readonly IMapper _mapper;

        public ReadService(IReadRepository<TEntity, TKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IQueryable<TResultDto> GetAll(IEnumerable<string> selectedProperties)
        {
            var selector = _selectorExpressionProvider.GetSelectorExpression(selectedProperties);

            return _repository.QueryAll()
                .Select(selector);
        }

        public IQueryable<TResultDto> GetById(TKey key, IEnumerable<string> selectedProperties)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "The key cannot be null.");

            var selector = _selectorExpressionProvider.GetSelectorExpression(selectedProperties);

            return _repository.QueryById(key)
                        .Select(selector);
        }

        public IQueryable<TResultDto> GetByIds(IEnumerable<TKey> keys, IEnumerable<string> selectedProperties)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selector = _selectorExpressionProvider.GetSelectorExpression(selectedProperties);

            return _repository.QueryByIds(keys)
                .Select(selector);
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryUserRepository;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserService
{
    public class SearchHistoryUserReadService : ReadService<SearchHistoryUser, Guid>
    {
        private readonly ISearchHistoryUserReadRepository _searchHistoryUserReadRepository;

        public SearchHistoryUserReadService(IReadRepository<SearchHistoryUser, Guid> repository, ISearchHistoryUserReadRepository searchHistoryUserReadRepository)
            : base(repository)
        {
            _searchHistoryUserReadRepository = searchHistoryUserReadRepository;
        }

        public IQueryable<SearchHistory> FetchSearchHistoryByUserIdQueryable(Guid key, IEnumerable<string> selectedProperties)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<SearchHistory>(_repository.GetDbContext(), selectedProperties);

            return _searchHistoryUserReadRepository.GetSearchHistoryByUserIdQueryable(key)
                .Select(selector);
        }

        public IQueryable<SearchHistory> FetchSearchHistoriesByUserIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<SearchHistory>(_repository.GetDbContext(), selectedProperties);

            return _searchHistoryUserReadRepository.GetSearchHistoriesByUserIdsQueryable(keys)
                .Select(selector);
        }

        public IQueryable<User> FetchUserBySearchHistoryIdQueryable(Guid key, IEnumerable<string> selectedProperties)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<User>(_repository.GetDbContext(), selectedProperties);

            return _searchHistoryUserReadRepository.GetUserBySearchHistoryIdQueryable(key)
                .Select(selector);
        }

        public IQueryable<User> FetchUsersBySearchHistoryIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<User>(_repository.GetDbContext(), selectedProperties);

            return _searchHistoryUserReadRepository.GetUsersBySearchHistoryIdsQueryable(keys)
                .Select(selector);
        }
    }

}

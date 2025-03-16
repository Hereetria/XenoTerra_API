using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Entity.UserPostTagRepository;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagService
{
    public class UserPostTagReadService : ReadService<UserPostTag, Guid>, IUserPostTagReadService
    {
        private readonly IUserPostTagReadRepository _userPostTagReadRepository;
        public UserPostTagReadService(IReadRepository<UserPostTag, Guid> repository, IUserPostTagReadRepository userPostTagReadRepository)
            : base(repository)
        {
            _userPostTagReadRepository = userPostTagReadRepository;
        }

        public IQueryable<Post> FetchPostByUserIdQueryable(Guid key, IEnumerable<string> selectedProperties)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<Post>(_repository.GetDbContext(), selectedProperties);

            return _userPostTagReadRepository.GetPostByUserIdQueryable(key)
                .Select(selector);
        }

        public IQueryable<Post> FetchPostsByUserIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties)
        {
            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<Post>(_repository.GetDbContext(), selectedProperties);

            return _userPostTagReadRepository.GetPostsByUserIdsQueryable(keys)
                .Select(selector);
        }

        public IQueryable<User> FetchUserByPostIdQueryable(Guid key, IEnumerable<string> selectedProperties)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<User>(_repository.GetDbContext(), selectedProperties);

            return _userPostTagReadRepository.GetUserByPostId(key)
                .Select(selector);
        }

        public IQueryable<User> FetchUsersByPostIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties)
        {

            if (keys == null || !keys.Any())
                throw new ArgumentNullException(nameof(keys), "The keys collection cannot be null or empty.");

            var selector = ReleatedProjectionExpressionProvider.CreateSelectorExpression<User>(_repository.GetDbContext(), selectedProperties);

            return _userPostTagReadRepository.GetUsersByPostIdsQueryable(keys)
                .Select(selector);
        }
    }

}

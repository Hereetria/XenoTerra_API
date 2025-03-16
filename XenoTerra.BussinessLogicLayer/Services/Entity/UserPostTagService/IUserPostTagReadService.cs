using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagService
{
    public interface IUserPostTagReadService : IReadService<UserPostTag, Guid> 
    {
        public IQueryable<Post> FetchPostsByUserIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties);
        public IQueryable<Post> FetchPostByUserIdQueryable(Guid key, IEnumerable<string> selectedProperties);
        public IQueryable<User> FetchUsersByPostIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties);
        public IQueryable<User> FetchUserByPostIdQueryable(Guid key, IEnumerable<string> selectedProperties);
    }
}

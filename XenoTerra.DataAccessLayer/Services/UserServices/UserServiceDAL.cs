

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DataAccessLayer.Repositories;
using AutoMapper.QueryableExtensions;

namespace XenoTerra.DataAccessLayer.Services.UserServices
{
    
    public class UserServiceDAL : GenericRepositoryDAL<User, ResultUserDto, ResultUserByIdDto, CreateUserDto, UpdateUserDto, Guid>, IUserServiceDAL

    {

        public UserServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQueryable<ResultUserDto> TGetSuggestedUsers(Guid userId)
        {
            var query = _context.Users
                .Where(user =>
                    !_context.Follows
                        .Where(f => f.FollowerId == userId)
                        .Select(f => f.FollowingId) 
                        .Contains(user.Id)
                 &&
            user.Id != userId
            );

            var result = query.ProjectTo<ResultUserDto>(_mapper.ConfigurationProvider);
            return result;
        }
    }
}
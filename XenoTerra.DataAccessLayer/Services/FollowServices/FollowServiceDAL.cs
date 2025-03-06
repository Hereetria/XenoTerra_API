

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.FollowServices
{
    
    public class FollowServiceDAL : GenericRepositoryDAL<Follow, ResultFollowDto, ResultFollowWithRelationsDto, CreateFollowDto, UpdateFollowDto, Guid>, IFollowServiceDAL

    {

        public FollowServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
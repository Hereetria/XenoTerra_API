

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.LikeServices
{
    
    public class LikeServiceDAL : GenericRepositoryDAL<Like, ResultLikeDto, ResultLikeWithRelationsDto, CreateLikeDto, UpdateLikeDto, Guid>, ILikeServiceDAL

    {

        public LikeServiceDAL(AppDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
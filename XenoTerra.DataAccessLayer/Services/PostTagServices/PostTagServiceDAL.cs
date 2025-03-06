

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.PostTagServices
{
    
    public class PostTagServiceDAL : GenericRepositoryDAL<PostTag, ResultPostTagDto, ResultPostTagWithRelationsDto, CreatePostTagDto, UpdatePostTagDto, Guid>, IPostTagServiceDAL

    {

        public PostTagServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
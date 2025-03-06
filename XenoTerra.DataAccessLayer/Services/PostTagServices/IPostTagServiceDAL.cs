
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.PostTagServices
{
    
    public interface IPostTagServiceDAL : IGenericRepositoryDAL<PostTag, ResultPostTagDto, ResultPostTagWithRelationsDto, CreatePostTagDto, UpdatePostTagDto, Guid>

    {

    }
}
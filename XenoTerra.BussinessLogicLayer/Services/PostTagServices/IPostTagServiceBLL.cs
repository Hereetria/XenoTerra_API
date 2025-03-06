
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.PostTagServices
{
        public interface IPostTagServiceBLL : IGenericRepositoryBLL<PostTag, ResultPostTagDto, CreatePostTagDto, UpdatePostTagDto, Guid>
    {
    }
}
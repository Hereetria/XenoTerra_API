using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.BussinessLogicLayer.Services.PostTagServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
using XenoTerra.DataAccessLayer.Services.PostServices;

namespace XenoTerra.BussinessLogicLayer.Services.PostTagServices
{
     public class PostTagServiceBLL : GenericRepositoryBLL<PostTag, ResultPostTagDto, ResultPostTagByIdDto, CreatePostTagDto, UpdatePostTagDto, Guid>, IPostTagServiceBLL
    {
        public PostTagServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}

using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.BussinessLogicLayer.Services.ViewStoryServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.ViewStoryServices
{
     public class ViewStoryServiceBLL : GenericRepositoryBLL<ViewStory, ResultViewStoryDto, ResultViewStoryWithRelationsDto, CreateViewStoryDto, UpdateViewStoryDto, Guid>, IViewStoryServiceBLL
    {
        public ViewStoryServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}
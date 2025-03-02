
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.ViewStoryServices
{
        public interface IViewStoryServiceBLL : IGenericRepositoryBLL<ViewStory, ResultViewStoryDto, ResultViewStoryByIdDto, CreateViewStoryDto, UpdateViewStoryDto, Guid>
    {

    }
}
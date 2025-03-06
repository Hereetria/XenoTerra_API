
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.ViewStoryServices
{
    
    public interface IViewStoryServiceDAL : IGenericRepositoryDAL<ViewStory, ResultViewStoryDto, ResultViewStoryWithRelationsDto, CreateViewStoryDto, UpdateViewStoryDto, Guid>

    {

    }
}
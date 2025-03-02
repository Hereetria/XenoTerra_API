
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.BussinessLogicLayer.Services.StoryServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.StoryServices
{
     public class StoryServiceBLL : GenericRepositoryBLL<Story, ResultStoryDto, ResultStoryByIdDto, CreateStoryDto, UpdateStoryDto, Guid>, IStoryServiceBLL
    {
        public StoryServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}
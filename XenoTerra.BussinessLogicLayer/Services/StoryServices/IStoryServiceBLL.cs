
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.StoryServices
{
        public interface IStoryServiceBLL : IGenericRepositoryBLL<Story, ResultStoryDto, ResultStoryByIdDto, CreateStoryDto, UpdateStoryDto, Guid>
    {

    }
}

using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.SavedPostServices
{
        public interface ISavedPostServiceBLL : IGenericRepositoryBLL<SavedPost, ResultSavedPostDto, ResultSavedPostByIdDto, CreateSavedPostDto, UpdateSavedPostDto, Guid>
    {

    }
}
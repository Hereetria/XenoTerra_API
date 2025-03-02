
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.SavedPostServices
{
    
    public interface ISavedPostServiceDAL : IGenericRepositoryDAL<SavedPost, ResultSavedPostDto, ResultSavedPostByIdDto ,CreateSavedPostDto, UpdateSavedPostDto, Guid>

    {

    }
}
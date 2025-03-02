
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.BussinessLogicLayer.Services.SavedPostServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.SavedPostServices
{
     public class SavedPostServiceBLL : GenericRepositoryBLL<SavedPost, ResultSavedPostDto, ResultSavedPostByIdDto, CreateSavedPostDto, UpdateSavedPostDto, Guid>, ISavedPostServiceBLL
    {
        public SavedPostServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}


using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.SavedPostServices
{
    
    public class SavedPostServiceDAL : GenericRepositoryDAL<SavedPost, ResultSavedPostDto, ResultSavedPostByIdDto, CreateSavedPostDto, UpdateSavedPostDto, Guid>, ISavedPostServiceDAL

    {

        public SavedPostServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
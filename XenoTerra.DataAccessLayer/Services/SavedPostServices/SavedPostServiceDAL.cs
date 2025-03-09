

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.SavedPostServices
{
    
    public class SavedPostServiceDAL : GenericRepositoryDAL<SavedPost, ResultSavedPostDto, ResultSavedPostWithRelationsDto, CreateSavedPostDto, UpdateSavedPostDto, Guid>, ISavedPostServiceDAL

    {

        public SavedPostServiceDAL(AppDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
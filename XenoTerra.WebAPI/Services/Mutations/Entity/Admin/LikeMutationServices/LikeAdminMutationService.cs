using AutoMapper;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.LikeMutationServices
{
    public class LikeAdminMutationService(IMapper mapper)
        : MutationService<Like, ResultLikeDto, CreateLikeDto, UpdateLikeDto, Guid>(mapper),
        ILikeAdminMutationService
    {
    }
}

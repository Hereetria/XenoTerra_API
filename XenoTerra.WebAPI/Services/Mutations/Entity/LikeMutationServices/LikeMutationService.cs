using AutoMapper;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.LikeMutationServices
{
    public class LikeMutationService(IMapper mapper)
        : MutationService<Like, ResultLikeDto, CreateLikeDto, UpdateLikeDto, Guid>(mapper),
        ILikeMutationService
    {
    }
}

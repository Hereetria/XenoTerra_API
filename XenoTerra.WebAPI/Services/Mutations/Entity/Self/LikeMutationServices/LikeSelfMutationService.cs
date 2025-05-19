using AutoMapper;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.LikeMutationServices
{
    public class LikeSelfMutationService(IMapper mapper)
        : MutationService<Like, ResultLikeDto, CreateLikeDto, UpdateLikeDto, Guid>(mapper),
        ILikeSelfMutationService
    {
    }
}

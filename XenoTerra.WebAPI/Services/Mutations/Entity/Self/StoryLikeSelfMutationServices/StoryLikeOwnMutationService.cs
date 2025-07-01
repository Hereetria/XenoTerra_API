using AutoMapper;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryLikeAdminMutationServices;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.StoryLikeSelfMutationServices
{
    public class StoryLikeOwnMutationService(IMapper mapper) 
        : MutationService<StoryLike, ResultStoryLikeOwnDto, CreateStoryLikeOwnDto, UpdateStoryLikeOwnDto, Guid>(mapper),
        IStoryLikeOwnMutationService
    {
    }
}

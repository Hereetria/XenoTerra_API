using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Admin;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryLikeAdminMutationServices
{
    public class StoryLikeAdminMutationService(IMapper mapper) 
        : MutationService<StoryLike, ResultStoryLikeAdminDto, CreateStoryLikeAdminDto, UpdateStoryLikeAdminDto, Guid>(mapper),
        IStoryLikeAdminMutationService
    {
    }
}
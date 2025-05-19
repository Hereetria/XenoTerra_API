using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostMutationServices
{
    public interface IPostSelfMutationService : IMutationService<Post, ResultPostDto, CreatePostDto, UpdatePostDto, Guid>
    {
    }
}

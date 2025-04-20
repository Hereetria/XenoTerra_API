using AutoMapper;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.LikeMutationServices
{
    public interface ILikeMutationService : IMutationService<Like, ResultLikeDto, CreateLikeDto, UpdateLikeDto, Guid>
    {
    }
}

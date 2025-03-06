
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.CommentServices
{
        public interface ICommentServiceBLL : IGenericRepositoryBLL<Comment, ResultCommentDto, CreateCommentDto, UpdateCommentDto, Guid>
    {

    }
}
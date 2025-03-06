
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.BussinessLogicLayer.Services.CommentServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.CommentServices
{
     public class CommentServiceBLL : GenericRepositoryBLL<Comment, ResultCommentDto, ResultCommentWithRelationsDto, CreateCommentDto, UpdateCommentDto, Guid>, ICommentServiceBLL
    {
        public CommentServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}
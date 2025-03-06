

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.CommentServices
{
    
    public class CommentServiceDAL : GenericRepositoryDAL<Comment, ResultCommentDto, ResultCommentWithRelationsDto, CreateCommentDto, UpdateCommentDto, Guid>, ICommentServiceDAL

    {

        public CommentServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
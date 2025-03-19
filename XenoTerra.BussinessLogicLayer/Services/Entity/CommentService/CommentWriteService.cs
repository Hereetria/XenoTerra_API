using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentService
{
    public class CommentWriteService : WriteService<Comment, ResultCommentDto, CreateCommentDto, UpdateCommentDto, Guid>, ICommentWriteService
    {
        public CommentWriteService(IWriteRepository<Comment, ResultCommentDto, Guid> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}

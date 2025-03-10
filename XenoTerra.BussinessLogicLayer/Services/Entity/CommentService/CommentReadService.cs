using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.CommentService
{
    public class CommentReadService : ReadService<Comment, ResultCommentWithRelationsDto, Guid>, ICommentReadService
    {
        public CommentReadService(IReadRepository<Comment, Guid> repository, IMapper mapper, SelectorExpressionProvider<Comment, ResultCommentWithRelationsDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}

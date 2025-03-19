using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.CommentRepository
{
    public class CommentWriteRepository : WriteRepository<Comment, ResultCommentDto, Guid>, ICommentWriteRepository
    {
        public CommentWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}

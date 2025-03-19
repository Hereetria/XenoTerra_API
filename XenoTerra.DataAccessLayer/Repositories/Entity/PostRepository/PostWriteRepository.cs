using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.PostRepository
{
    public class PostWriteRepository : WriteRepository<Post, ResultPostDto, Guid>, IPostWriteRepository
    {
        public PostWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}

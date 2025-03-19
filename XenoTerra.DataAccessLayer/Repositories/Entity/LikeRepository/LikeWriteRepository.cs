using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.LikeRepository
{
    public class LikeWriteRepository : WriteRepository<Like, ResultLikeDto, Guid>, ILikeWriteRepository
    {
        public LikeWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}

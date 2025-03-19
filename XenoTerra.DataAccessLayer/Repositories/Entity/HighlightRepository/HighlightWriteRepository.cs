using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.HighlightRepository
{
    public class HighlightWriteRepository : WriteRepository<Highlight, ResultHighlightDto, Guid>, IHighlightWriteRepository
    {
        public HighlightWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}

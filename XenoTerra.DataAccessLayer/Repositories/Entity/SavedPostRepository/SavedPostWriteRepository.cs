using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SavedPostRepository
{
    public class SavedPostWriteRepository : WriteRepository<SavedPost, ResultSavedPostDto, Guid>, ISavedPostWriteRepository
    {
        public SavedPostWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}

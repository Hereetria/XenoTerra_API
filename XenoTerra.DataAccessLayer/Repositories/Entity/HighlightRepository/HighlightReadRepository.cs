using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.HighlightRepository
{
    public class HighlightReadRepository : ReadRepository<Highlight, ResultHighlightWithRelationsDto, Guid>, IHighlightReadRepository
    {
        public HighlightReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}

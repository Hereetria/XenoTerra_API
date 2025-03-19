using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.HighlightRepository
{
    public interface IHighlightReadRepository : IReadRepository<Highlight, ResultHighlightWithRelationsDto, Guid>
    {
    }
}

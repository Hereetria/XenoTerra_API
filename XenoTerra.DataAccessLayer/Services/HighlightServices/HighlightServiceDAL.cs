

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.HighlightServices
{
    
    public class HighlightServiceDAL : GenericRepositoryDAL<Highlight, ResultHighlightDto, ResultHighlightByIdDto, CreateHighlightDto, UpdateHighlightDto, Guid>, IHighlightServiceDAL

    {

        public HighlightServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
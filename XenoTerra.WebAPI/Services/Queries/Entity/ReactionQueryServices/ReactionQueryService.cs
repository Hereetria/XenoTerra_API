using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices
{
    public class ReactionQueryService : QueryService<Reaction, ResultReactionWithRelationsDto, Guid>, IReactionQueryService
    {
        public ReactionQueryService(IReadService<Reaction, ResultReactionWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper)
        {
        }
    }
}

using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices
{
    public class ReactionQueryService : BaseQueryService<Reaction, ResultReactionDto, Guid>, IReactionQueryService
    {
        public ReactionQueryService(IReadService<Reaction, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}

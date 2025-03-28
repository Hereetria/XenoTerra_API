using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices
{
    public class ReactionQueryService : QueryService<Reaction, Guid>, IReactionQueryService
    {
        public ReactionQueryService(IReadService<Reaction, Guid> readService)
            : base(readService)
        {
        }
    }
}

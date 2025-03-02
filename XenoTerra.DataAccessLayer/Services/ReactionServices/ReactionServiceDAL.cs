

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.ReactionServices
{
    
    public class ReactionServiceDAL : GenericRepositoryDAL<Reaction, ResultReactionDto, ResultReactionByIdDto, CreateReactionDto, UpdateReactionDto, Guid>, IReactionServiceDAL

    {

        public ReactionServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
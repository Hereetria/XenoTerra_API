using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.MessageResolvers
{
    public interface IMessageResolver : IEntityResolver<Message, Guid>
    {
    }
}

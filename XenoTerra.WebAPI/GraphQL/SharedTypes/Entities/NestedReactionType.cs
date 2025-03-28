using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedReactionType : ObjectType<ResultReactionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReactionDto> descriptor)
        {
            descriptor.Field(f => f.ReactionId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Payload)
                .Type<StringType>();

            descriptor.Field(f => f.MessageId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();
        }
    }
}

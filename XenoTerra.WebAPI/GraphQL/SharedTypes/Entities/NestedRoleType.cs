using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedRoleType : ObjectType<ResultRoleDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRoleDto> descriptor)
        {
            descriptor.Field(f => f.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Name)
                .Type<StringType>();
        }
    }
}

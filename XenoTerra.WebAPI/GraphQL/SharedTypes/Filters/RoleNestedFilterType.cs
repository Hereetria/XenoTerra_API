using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class RoleNestedFilterType : FilterInputType<Role>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Role> descriptor)
        {
            descriptor.Name("RoleNestedFilterInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.Name);
        }
    }
}

using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.RoleQueries.Filters
{
    public class RoleFilterType : FilterInputType<Role>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Role> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.Name);
        }
    }
}

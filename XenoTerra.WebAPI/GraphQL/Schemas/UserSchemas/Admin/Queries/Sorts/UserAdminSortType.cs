using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries.Sorts
{
    public class UserAdminSortType : SortInputType<User>
    {
        protected override void Configure(ISortInputTypeDescriptor<User> descriptor)
        {
        descriptor.Name("UserAdminSortInput");
        }
    }
}

using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Sorts
{
    public class UserCommonSelfSortType : SortInputType<User>
    {
        protected override void Configure(ISortInputTypeDescriptor<User> descriptor)
        {
            descriptor.Name("UserSelfSortInput");
        }
    }
}

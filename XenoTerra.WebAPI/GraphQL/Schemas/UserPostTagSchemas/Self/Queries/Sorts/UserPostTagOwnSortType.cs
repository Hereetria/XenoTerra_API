using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Sorts
{
    public class UserPostTagOwnSortType : SortInputType<UserPostTag>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserPostTag> descriptor)
        {
        descriptor.Name("UserPostTagOwnSortInput");
        }
    }
}

using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Sorts;

public class UserPostTagAdminSortType : SortInputType<UserPostTag>
{
    protected override void Configure(ISortInputTypeDescriptor<UserPostTag> descriptor)
    {
    descriptor.Name("UserPostTagAdminSortInput");
    }
}

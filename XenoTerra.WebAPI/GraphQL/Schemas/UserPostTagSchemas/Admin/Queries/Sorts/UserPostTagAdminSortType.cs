using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Sorts;

public class UserPostTagAdminSortType : SortAdminInputType<UserPostTag>
{
    protected override void Configure(ISortInputTypeDescriptor<UserPostTag> descriptor)
    {
    }
}

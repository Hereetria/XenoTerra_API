using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Sorts;

public class UserPostTagSortType : SortInputType<UserPostTag>
{
    protected override void Configure(ISortInputTypeDescriptor<UserPostTag> descriptor)
    {
    }
}

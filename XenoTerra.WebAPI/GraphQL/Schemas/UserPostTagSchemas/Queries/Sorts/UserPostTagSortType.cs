using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.UserPostTagQueries.Queries
{
    public class UserPostTagSortType : SortInputType<UserPostTag>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserPostTag> descriptor)
        {
        }
    }
}

using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries.Sorts
{
    public class UserSelfSortType : SortSelfInputType<User>
    {
        protected override void Configure(ISortInputTypeDescriptor<User> descriptor)
        {
        }
    }
}

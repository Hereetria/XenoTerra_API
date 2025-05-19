using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Sorts
{
    public class UserPrivateSelfSortType : UserCommonSelfSortType
    {
        protected override void Configure(ISortInputTypeDescriptor<User> descriptor)
        {
        }
    }
}

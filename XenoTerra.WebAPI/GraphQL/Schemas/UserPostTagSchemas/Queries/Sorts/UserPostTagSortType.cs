using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.UserPostTagQueries.Queries
{
    public class UserPostTagSortType : SortInputType<UserPostTag>
    {
        protected override void Configure(ISortInputTypeDescriptor<UserPostTag> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);

            descriptor.Field(f => f.Post)
                .Type<PostNestedSortType>();

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}

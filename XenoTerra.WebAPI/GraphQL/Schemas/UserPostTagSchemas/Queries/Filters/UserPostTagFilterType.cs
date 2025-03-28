using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.UserPostTagQueries.Filters
{
    public class UserPostTagFilterType : FilterInputType<UserPostTag>
    {
        protected override void Configure(IFilterInputTypeDescriptor<UserPostTag> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);

            descriptor.Field(f => f.Post)
                .Type<PostNestedFilterType>();

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();
        }
    }
}

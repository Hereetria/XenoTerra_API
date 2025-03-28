using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostQueries.Filters
{
    public class SavedPostFilterType : FilterInputType<SavedPost>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SavedPost> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.SavedPostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.SavedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.Post)
                .Type<PostNestedFilterType>();
        }
    }
}

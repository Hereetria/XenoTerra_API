using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.LikeQueries.Filters
{
    public class LikeFilterType : FilterInputType<Like>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Like> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.LikeId);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.LikedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();

            descriptor.Field(f => f.Post)
                .Type<PostNestedFilterType>();
        }
    }
}

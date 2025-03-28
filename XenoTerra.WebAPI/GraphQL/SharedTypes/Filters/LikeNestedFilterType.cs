using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class LikeNestedFilterType : FilterInputType<Like>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Like> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.LikeId);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.LikedAt);
        }
    }
}

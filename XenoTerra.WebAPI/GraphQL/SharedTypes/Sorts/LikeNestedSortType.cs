using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class LikeNestedSortType : SortInputType<Like>
    {
        protected override void Configure(ISortInputTypeDescriptor<Like> descriptor)
        {
            descriptor.Name("LikeNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.LikeId);
            descriptor.Field(f => f.PostId);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.LikedAt);
        }
    }
}

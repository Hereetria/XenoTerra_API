using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class MediaNestedSortType : SortInputType<Media>
    {
        protected override void Configure(ISortInputTypeDescriptor<Media> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.MediaId);
            descriptor.Field(f => f.PhotoUrl);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.UploadedAt);
        }
    }
}

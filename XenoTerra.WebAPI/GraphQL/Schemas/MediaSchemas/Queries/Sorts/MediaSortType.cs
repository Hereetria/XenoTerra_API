using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.MediaQueries.Sorts
{
    public class MediaSortType : SortInputType<Media>
    {
        protected override void Configure(ISortInputTypeDescriptor<Media> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.MediaId);
            descriptor.Field(f => f.PhotoUrl);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.UploadedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}

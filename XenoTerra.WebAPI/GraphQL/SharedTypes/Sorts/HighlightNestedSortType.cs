using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class HighlightNestedSortType : SortInputType<Highlight>
    {
        protected override void Configure(ISortInputTypeDescriptor<Highlight> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.HighlightId);
            descriptor.Field(f => f.Name);
            descriptor.Field(f => f.ProfilePicturePath);
        }
    }
}

using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class HighlightNestedFilterType : FilterInputType<Highlight>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Highlight> descriptor)
        {
            descriptor.Name("HighlightNestedFilterInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.HighlightId);
            descriptor.Field(f => f.Name);
            descriptor.Field(f => f.ProfilePicturePath);
        }
    }
}

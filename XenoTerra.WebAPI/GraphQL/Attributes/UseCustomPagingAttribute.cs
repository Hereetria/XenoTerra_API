using HotChocolate.Types.Descriptors;
using System.Reflection;
using XenoTerra.WebAPI.GraphQL.Middlewares;

namespace XenoTerra.WebAPI.GraphQL.Attributes
{
    public class UseCustomPagingAttribute : ObjectFieldDescriptorAttribute
    {
        protected override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.Argument("first", a => a.Type<IntType>().Description("Returns the first n elements from the list."));
            descriptor.Argument("after", a => a.Type<StringType>().Description("Returns the elements after this cursor."));
            descriptor.Argument("last", a => a.Type<IntType>().Description("Returns the last n elements from the list."));
            descriptor.Argument("before", a => a.Type<StringType>().Description("Returns the elements before this cursor."));

            descriptor.Use<CustomPaginationMiddleware>();
        }
    }
}

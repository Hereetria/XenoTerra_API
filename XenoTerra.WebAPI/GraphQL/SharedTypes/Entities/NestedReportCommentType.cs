using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedReportCommentType : ObjectType<ResultReportCommentDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportCommentDto> descriptor)
        {
            descriptor.Field(f => f.ReportCommentId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.ReporterUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.CommentId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Reason)
                .Type<StringType>();

            descriptor.Field(f => f.ReportedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}

namespace XenoTerra.WebAPI.Schemas.Queries.ReportCommentQueries
{
    public class ReportCommentQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

        //[UseProjection]
        //[GraphQLDescription("Get all ReportComments")]
        //public IQueryable<ResultReportCommentDto> GetAllReportComments([Service] IReportCommentServiceBLL reportCommentServiceBLL)
        //{
        //    return reportCommentServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get ReportComment by ID")]
        //public IQueryable<ResultReportCommentByIdDto> GetReportCommentById(Guid id, [Service] IReportCommentServiceBLL reportCommentServiceBLL)
        //{
        //    var result = reportCommentServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"ReportComment with ID {id} not found");
        //    }
        //    return result;
        //}
    }

}

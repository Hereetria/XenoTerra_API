namespace XenoTerra.WebAPI.Helpers
{
    public static class DateConversionExtensions
    {
        public static DateTime ToDateTime(this DateOnly dateOnly)
        {
            return dateOnly.ToDateTime(TimeOnly.MinValue);
        }
    }
}

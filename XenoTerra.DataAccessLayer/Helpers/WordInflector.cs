using Humanizer;

namespace XenoTerra.DataAccessLayer.Helpers
{
    public static class WordInflector
    {
        public static string ConvertToSingular(string pluralWord)
        {
            if (string.IsNullOrWhiteSpace(pluralWord))
                throw new ArgumentException("Input cannot be null or empty.", nameof(pluralWord));

            return pluralWord.Singularize(false);
        }

        public static string ConvertToPlural(string singularWord)
        {
            if (string.IsNullOrWhiteSpace(singularWord))
                throw new ArgumentException("Input cannot be null or empty.", nameof(singularWord));

            return singularWord.Pluralize();
        }
    }
}

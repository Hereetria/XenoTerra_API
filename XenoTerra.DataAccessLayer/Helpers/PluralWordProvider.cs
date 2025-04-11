namespace XenoTerra.WebAPI.Utils
{
    public static class WordInflector
    {
        public static string ConvertToSingular(string pluralWord)
        {
            if (string.IsNullOrWhiteSpace(pluralWord))
                throw new ArgumentException("Input cannot be null or empty.", nameof(pluralWord));

            if (pluralWord.EndsWith("ies"))
            {
                return pluralWord.Substring(0, pluralWord.Length - 3) + "y";
            }
            else if (pluralWord.EndsWith("ves"))
            {
                return pluralWord.Substring(0, pluralWord.Length - 3) + "f";
            }
            else if (pluralWord.EndsWith("es") && (pluralWord.Length > 2))
            {
                return pluralWord.Substring(0, pluralWord.Length - 2);
            }
            else if (pluralWord.EndsWith("s") && (pluralWord.Length > 1))
            {
                return pluralWord.Substring(0, pluralWord.Length - 1);
            }

            return pluralWord;
        }

        public static string ConvertToPlural(string singularWord)
        {
            if (string.IsNullOrWhiteSpace(singularWord))
                throw new ArgumentException("Input cannot be null or empty.", nameof(singularWord));

            if (singularWord.EndsWith("ies") || singularWord.EndsWith("ves") || singularWord.EndsWith("es") || singularWord.EndsWith("s"))
            {
                return singularWord;
            }

            if (singularWord.EndsWith("y") && singularWord.Length > 1 && !"aeiou".Contains(singularWord[singularWord.Length - 2]))
            {
                return singularWord.Substring(0, singularWord.Length - 1) + "ies";
            }
            else if (singularWord.EndsWith("f"))
            {
                return singularWord.Substring(0, singularWord.Length - 1) + "ves";
            }
            else if (singularWord.EndsWith("fe"))
            {
                return singularWord.Substring(0, singularWord.Length - 2) + "ves";
            }
            else if (singularWord.EndsWith("o") || singularWord.EndsWith("ch") || singularWord.EndsWith("sh") || singularWord.EndsWith("x") || singularWord.EndsWith("s"))
            {
                return singularWord + "es";
            }
            else
            {
                return singularWord + "s";
            }
        }
    }
}

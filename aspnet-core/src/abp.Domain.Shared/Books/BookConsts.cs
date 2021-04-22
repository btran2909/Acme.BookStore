namespace abp.Books
{
    public static class BookConsts
    {
        private const string DefaultSorting = "{0}Title asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Book." : string.Empty);
        }

    }
}
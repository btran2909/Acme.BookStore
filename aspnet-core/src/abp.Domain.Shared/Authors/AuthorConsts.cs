namespace abp.Authors
{
    public static class AuthorConsts
    {
        private const string DefaultSorting = "{0}NameSurname asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Author." : string.Empty);
        }

    }
}
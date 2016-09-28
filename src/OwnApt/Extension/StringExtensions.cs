namespace OwnApt.Common.Extension
{
    public static class StringExtensions
    {
        #region Public Methods

        public static string ValueIfNullOrEmpty(this string str, string value)
        {
            return str.IsNullOrEmpty() ? value : str;
        }

        public static string ValueIfNullOrWhitespace(this string str, string value)
        {
            return str.IsNullOrWhiteSpace() ? value : str;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        #endregion Public Methods
    }
}

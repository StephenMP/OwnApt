namespace OwnApt.Common.Extension
{
    public static class StringExtensions
    {
        #region Public Methods

        public static string ValueIfNullOrEmpty(this string str, string value)
        {
            return string.IsNullOrEmpty(str) ? value : str;
        }

        public static string ValueIfNullOrWhitespace(this string str, string value)
        {
            return string.IsNullOrWhiteSpace(str) ? value : str;
        }

        #endregion Public Methods
    }
}

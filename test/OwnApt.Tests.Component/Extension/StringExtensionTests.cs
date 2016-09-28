using OwnApt.Common.Extension;
using Xunit;

namespace OwnApt.Tests.Component.Extension
{
    public class StringExtensionTests
    {
        #region Public Methods

        [Fact]
        public void CanGetValueWithEmptyOrWhitespaceString()
        {
            var emptyString = "";
            var whitespaceString = "               ";

            var stringFromNullOrEmptyCheck = emptyString.ValueIfNullOrEmpty("NullOrEmpty");
            var stringFromNullOrWhitespaceCheck = whitespaceString.ValueIfNullOrWhitespace("NullOrWhitespace");

            Assert.NotNull(emptyString);
            Assert.NotNull(whitespaceString);
            Assert.NotNull(stringFromNullOrEmptyCheck);
            Assert.NotNull(stringFromNullOrWhitespaceCheck);
            Assert.Equal(stringFromNullOrEmptyCheck, "NullOrEmpty");
            Assert.Equal(stringFromNullOrWhitespaceCheck, "NullOrWhitespace");
        }

        [Fact]
        public void CanGetValueWithNullString()
        {
            string nullString = null;

            var stringFromNullOrEmptyCheck = nullString.ValueIfNullOrEmpty("NullOrEmpty");
            var stringFromNullOrWhitespaceCheck = nullString.ValueIfNullOrWhitespace("NullOrWhitespace");

            Assert.Null(nullString);
            Assert.NotNull(stringFromNullOrEmptyCheck);
            Assert.NotNull(stringFromNullOrWhitespaceCheck);
            Assert.Equal(stringFromNullOrEmptyCheck, "NullOrEmpty");
            Assert.Equal(stringFromNullOrWhitespaceCheck, "NullOrWhitespace");
        }

        [Fact]
        public void IsNullOrEmptyOrWhitespaceTests()
        {
            string nullString = null;
            var emptyString = "";
            var whitespaceString = "         ";

            Assert.True(nullString.IsNullOrEmpty());
            Assert.True(nullString.IsNullOrWhiteSpace());
            Assert.True(emptyString.IsNullOrEmpty());
            Assert.True(emptyString.IsNullOrWhiteSpace());
            Assert.True(whitespaceString.IsNullOrWhiteSpace());
        }

        #endregion Public Methods
    }
}

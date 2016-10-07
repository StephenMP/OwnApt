using OwnApt.Common.Attributes;
using Xunit;

namespace OwnApt.Tests.Component.Attributes
{
    public class EnumPropertiesTests
    {
        #region Public Methods

        [Fact]
        public void CanNewUpEnumProprtiesAttribute()
        {
            var attribute = new EnumPropertiesAttribute("Short Description", "Description");

            Assert.NotNull(attribute);
            Assert.Equal(attribute.ShortDescription, "Short Description");
            Assert.Equal(attribute.Description, "Description");
        }

        #endregion Public Methods
    }
}

using OwnApt.Common.Attributes;
using OwnApt.Common.Extension;
using Xunit;

namespace OwnApt.Tests.Component.Extension
{
    internal enum TestEnum
    {
        [EnumProperties("Test 1", "This is a test for Test 1")]
        TestEnumValue1,

        [EnumProperties("Test 2", "This is a test for Test 2")]
        TestEnumValue2,

        TestEnumValue3
    }

    public class EnumPropertiesExtensionTests
    {
        #region Public Methods

        [Fact]
        public void CannotRetriveEnumPropertiesAttributeWhenThereIsNoEnumPropertiesAttribute()
        {
            var enum3 = TestEnum.TestEnumValue3;
            var enumProperties = enum3.GetAttribute<EnumPropertiesAttribute>();

            Assert.Null(enumProperties);
        }

        [Fact]
        public void CanRetrieveDescriptions()
        {
            var enum1 = TestEnum.TestEnumValue1;
            var enum2 = TestEnum.TestEnumValue2;

            Assert.Equal(enum1.GetEnumPropertiesDescription(), "This is a test for Test 1");
            Assert.Equal(enum2.GetEnumPropertiesDescription(), "This is a test for Test 2");
        }

        [Fact]
        public void CanRetrieveDescriptionWhenThereIsNoEnumPropertiesAttribute()
        {
            var enum3 = TestEnum.TestEnumValue3;
            Assert.Equal(enum3.GetEnumPropertiesDescription(), enum3.ToString());
        }

        [Fact]
        public void CanRetrieveShortDescriptions()
        {
            var enum1 = TestEnum.TestEnumValue1;
            var enum2 = TestEnum.TestEnumValue2;

            Assert.Equal(enum1.GetEnumPropertiesShortDescription(), "Test 1");
            Assert.Equal(enum2.GetEnumPropertiesShortDescription(), "Test 2");
        }

        [Fact]
        public void CanRetrieveShortDescriptionWhenThereIsNoEnumPropertiesAttribute()
        {
            var enum3 = TestEnum.TestEnumValue3;
            Assert.Equal(enum3.GetEnumPropertiesShortDescription(), enum3.ToString());
        }

        [Fact]
        public void CanRetriveEnumPropertiesAttribute()
        {
            var enum1 = TestEnum.TestEnumValue1;
            var enumProperties = enum1.GetAttribute<EnumPropertiesAttribute>();

            Assert.NotNull(enumProperties);
            Assert.Equal(enumProperties.Description, "This is a test for Test 1");
            Assert.Equal(enumProperties.ShortDescription, "Test 1");
        }

        #endregion Public Methods
    }
}

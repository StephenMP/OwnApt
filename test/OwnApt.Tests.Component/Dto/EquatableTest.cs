using OwnApt.Common.Dto;
using OwnApt.Common.Extension;
using System;
using System.Collections.Generic;
using Xunit;

namespace OwnApt.Tests.Component.Dto
{
    public class EquatableTest
    {
        #region Public Methods

        [Fact]
        public void CanEquate()
        {
            var testSubObjects = new List<TestSubObject>
            {
                new TestSubObject
                {
                    Strings = new string[] { RandomString(), RandomString(), RandomString() }
                },
                new TestSubObject
                {
                    Strings = new string[] { RandomString(), RandomString(), RandomString() }
                },
                new TestSubObject
                {
                    Strings = new string[] { RandomString(), RandomString(), RandomString() }
                }
            };

            var value = new Random().Next();

            var orig = new TestObject { SubObjects = testSubObjects, Value = value };
            var copy = new TestObject { SubObjects = testSubObjects, Value = value };

            Assert.Equal(orig, copy);
        }

        [Fact]
        public void CannotEquatWhenObjectsAreNotEqual()
        {
            var orig = new TestObject
            {
                SubObjects = new List<TestSubObject>
                {
                    new TestSubObject
                    {
                        Strings = new string[] { RandomString(), RandomString(), RandomString(), "S" }
                    },
                    new TestSubObject
                    {
                        Strings = new string[] { RandomString(), RandomString(), RandomString(), "S" }
                    },
                    new TestSubObject
                    {
                        Strings = new string[] { RandomString(), RandomString(), RandomString(), "S" }
                    }
                },
                Value = new Random().Next()
            };

            var copy = new TestObject
            {
                SubObjects = new List<TestSubObject>
                {
                    new TestSubObject
                    {
                        Strings = new string[] { RandomString(), RandomString(), RandomString(), "A" }
                    },
                    new TestSubObject
                    {
                        Strings = new string[] { RandomString(), RandomString(), RandomString(), "A" }
                    },
                    new TestSubObject
                    {
                        Strings = new string[] { RandomString(), RandomString(), RandomString(), "A" }
                    }
                },
                Value = new Random().Next()
            };

            Assert.NotEqual(orig, copy);
        }

        #endregion Public Methods

        #region Private Methods

        private static string RandomString()
        {
            return Guid.NewGuid().ToString();
        }

        #endregion Private Methods
    }

    internal class TestObject : Equatable<TestObject>
    {
        #region Public Properties

        public List<TestSubObject> SubObjects { get; set; }
        public int Value { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override int GetHashCode()
        {
            return this.SubObjects.GetHashCodeSafe()
                ^ this.Value.GetHashCodeSafe();
        }

        #endregion Public Methods
    }

    internal class TestSubObject : Equatable<TestSubObject>
    {
        #region Public Properties

        public string[] Strings { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override int GetHashCode()
        {
            return this.Strings.GetHashCodeSafe();
        }

        #endregion Public Methods
    }
}

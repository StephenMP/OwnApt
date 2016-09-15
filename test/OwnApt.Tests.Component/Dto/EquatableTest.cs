using OwnApt.Common.Dto;
using OwnApt.Common.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            AreEqual(orig, copy);
        }

        [Fact]
        public void NullEquals()
        {
            TestObject orig = null;
            TestObject copy = null;
            Assert.Equal(orig, copy);
        }

        [Fact]
        public void NullNotEquals()
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

            TestObject copy = null;

            Assert.NotEqual(orig, copy);
        }

        [Fact]
        public void CanEquateReflectively()
        {
            var classTypes = this.GetType()
                                 .GetTypeInfo()
                                 .Assembly
                                 .GetTypes()
                                 .Where(t => t != typeof(Equatable) && typeof(Equatable).IsAssignableFrom(t));

            foreach (var type in classTypes)
            {
                var orig = Activator.CreateInstance(type) as Equatable;
                var copy = Activator.CreateInstance(type) as Equatable;
                AreEqual(orig, copy);
            }
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

            AreNotEqual(orig, copy);
        }

        #endregion Public Methods

        #region Private Methods

        private static string RandomString()
        {
            return Guid.NewGuid().ToString();
        }

        #endregion Private Methods

        public static void AreEqual(Equatable orig, Equatable copy)
        {
            Assert.Equal(orig, copy);
            Assert.Equal(orig.GetHashCode(), copy.GetHashCode());
            Assert.True(orig.Equals(copy));
        }

        public static void AreNotEqual(Equatable orig, Equatable copy)
        {
            Assert.NotEqual(orig, copy);
            Assert.NotEqual(orig.GetHashCode(), copy.GetHashCode());
            Assert.False(orig.Equals(copy));
        }

        internal class TestObject : Equatable
        {
            #region Public Properties

            public List<TestSubObject> SubObjects { get; set; }
            public int Value { get; set; }

            #endregion Public Properties
        }

        internal class TestSubObject : Equatable
        {
            #region Public Properties

            public string[] Strings { get; set; }

            #endregion Public Properties
        }
    }
}
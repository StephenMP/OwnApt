using OwnApt.Common.Dto;
using OwnApt.Common.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OwnApt.Tests.Component.Dto
{
    internal class TestSubObject : Equatable<TestSubObject>
    {
        public string[] Strings { get; set; }

        public override int GetHashCode()
        {
            return this.Strings.GetHashCodeSafe();
        }
    }

    internal class TestObject : Equatable<TestObject>
    {
        public List<TestSubObject> SubObjects { get; set; }
        public int Value { get; set; }

        public override int GetHashCode()
        {
            return this.SubObjects.GetHashCodeSafe()
                ^ this.Value.GetHashCodeSafe();
        }
    }

    public class EquatableTest
    {
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
                },
            };

            var value = new Random().Next();

            var orig = new TestObject { SubObjects = testSubObjects, Value = value };
            var copy = new TestObject { SubObjects = testSubObjects, Value = value };

            Assert.Equal(orig, copy);
        }

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
                    },
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
                    },
                },
                Value = new Random().Next()
            };

            Assert.NotEqual(orig, copy);
        }

        private static string RandomString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

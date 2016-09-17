using OwnApt.Common.Dto;
using OwnApt.Common.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace OwnApt.Tests.Component.Dto
{
    public class EquatableSteps
    {
        private readonly TestObject[] testObjects = { null, null };
        internal TestSubObject testSubObject;
        #region Public Methods

        [Fact]
        internal void ThenICanVerifyTheObjectsAreEqual()
        {
            Assert.Equal(this.testObjects[0], this.testObjects[1]);
        }

        internal void GivenIHaveATestSubObject()
        {
            this.testSubObject = new TestSubObject(true);
        }

        internal void GivenIHaveATestObject(int index, int value, TestSubObject subObject = null)
        {
            subObject = subObject ?? new TestSubObject(true);
            testObjects[index] = new TestObject(value, subObject);
        }

        internal void GivenIHaveNullTestObjects()
        {
            this.testObjects[0] = null;
            this.testObjects[1] = null;
        }

        internal void ThenICanVerifyTheObjectsAreNotEqual()
        {
            Assert.NotEqual(this.testObjects[0], this.testObjects[1]);
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
            public TestObject()
            {
                this.SubObjects = new List<TestSubObject>();
            }

            public TestObject(int value, params TestSubObject[] testSubObject)
            {
                this.SubObjects = new List<TestSubObject>();
                this.SubObjects.AddRange(testSubObject);
                this.Value = value;
            }

            #region Public Properties

            public List<TestSubObject> SubObjects { get; set; }
            public int Value { get; set; }

            #endregion Public Properties
        }

        internal class TestSubObject : Equatable
        {
            public TestSubObject() : this(false) { }

            public TestSubObject(bool random)
            {
                if (random)
                {
                    this.Strings = new string[] { RandomString(), RandomString(), RandomString() };
                }
            }
            #region Public Properties

            public string[] Strings { get; set; }

            #endregion Public Properties
        }
    }
}
using OwnApt.Common.Extension;
using System;
using System.Collections.Generic;
using Xunit;

namespace OwnApt.Tests.Component.Extension
{
    public class ObjectExtensionsSteps
    {
        #region Private Fields

        private int hash;
        private TestObject testObject;
        private List<TestObject> testObjects;

        #endregion Private Fields

        #region Internal Methods

        internal void GivenIHaveAnEquatableObject()
        {
            this.testObject = new TestObject();
        }

        internal void GivenIHaveAnEquatableObjects()
        {
            this.testObjects = new List<TestObject>
            {
                new TestObject(),
                new TestObject(),
                new TestObject(),
                new TestObject(),
                new TestObject()
            };
        }

        internal void ThenICanVerifyICanGetHashCodeSafe()
        {
            Assert.True(hash != 0);
        }

        internal void WhenIGetHashCodeSafe()
        {
            this.hash = this.testObject.GetHashCodeSafe();
        }

        internal void WhenIGetHashCodeSafeForCollection()
        {
            this.hash = this.testObjects.GetHashCodeSafe();
        }

        #endregion Internal Methods
    }

    internal class TestObject
    {
        #region Public Constructors

        public TestObject()
        {
            this.Key = new Random().Next();
            this.Value = Guid.NewGuid().ToString();
        }

        #endregion Public Constructors

        #region Public Properties

        public int Key { get; set; }
        public string Value { get; set; }

        #endregion Public Properties
    }
}

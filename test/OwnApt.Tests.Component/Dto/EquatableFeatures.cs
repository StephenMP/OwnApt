using OwnApt.Common.Dto;
using OwnApt.Common.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace OwnApt.Tests.Component.Dto
{
    public class EquatableFeatures
    {
        private readonly EquatableSteps steps;

        public EquatableFeatures()
        {
            this.steps = new EquatableSteps();
        }

        [Fact]
        public void CanEquateEqualObjects()
        {
            this.steps.GivenIHaveATestSubObject();
            this.steps.GivenIHaveATestObject(0, 1, this.steps.testSubObject);
            this.steps.GivenIHaveATestObject(1, 1, this.steps.testSubObject);
            this.steps.ThenICanVerifyTheObjectsAreEqual();
        }

        [Fact]
        public void CanEquateWhenBothAreNull()
        {
            this.steps.GivenIHaveNullTestObjects();
            this.steps.ThenICanVerifyTheObjectsAreEqual();
        }

        [Fact]
        public void CannotEquateWhenOnlyOneIsNull()
        {
            this.steps.GivenIHaveNullTestObjects();
            this.steps.GivenIHaveATestObject(0, 1);
            this.steps.ThenICanVerifyTheObjectsAreNotEqual();
        }

        [Fact]
        public void CanEquateUsingReflection()
        {
            var classTypes = this.GetType().GetTypeInfo().Assembly.GetTypes()
                                 .Where(t => t != typeof(Equatable) && typeof(Equatable).IsAssignableFrom(t));

            foreach (var type in classTypes)
            {
                var orig = Activator.CreateInstance(type) as Equatable;
                var copy = Activator.CreateInstance(type) as Equatable;
                Assert.Equal(orig, copy);
            }
        }

        [Fact]
        public void CannotEquateUnequalObjects()
        {
            this.steps.GivenIHaveATestSubObject();
            this.steps.GivenIHaveATestObject(0, 1);
            this.steps.GivenIHaveATestObject(1, 2);
            this.steps.ThenICanVerifyTheObjectsAreNotEqual();
        }
    }
}
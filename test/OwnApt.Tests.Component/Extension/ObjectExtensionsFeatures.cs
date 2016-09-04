using Xunit;

namespace OwnApt.Tests.Component.Extension
{
    public class ObjectExtensionsFeatures
    {
        #region Private Fields

        private ObjectExtensionsSteps steps;

        #endregion Private Fields

        #region Public Constructors

        public ObjectExtensionsFeatures()
        {
            this.steps = new ObjectExtensionsSteps();
        }

        #endregion Public Constructors

        #region Public Methods

        [Fact]
        public void CanGetHashCodeSafeForACollection()
        {
            this.steps.GivenIHaveAnEquatableObjects();
            this.steps.WhenIGetHashCodeSafeForCollection();
            this.steps.ThenICanVerifyICanGetHashCodeSafe();
        }

        [Fact]
        public void CanGetHashCodeSafeForObject()
        {
            this.steps.GivenIHaveAnEquatableObject();
            this.steps.WhenIGetHashCodeSafe();
            this.steps.ThenICanVerifyICanGetHashCodeSafe();
        }

        #endregion Public Methods
    }
}

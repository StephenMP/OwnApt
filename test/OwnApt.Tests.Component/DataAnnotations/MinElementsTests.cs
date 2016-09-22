using OwnApt.Common.DataAnnotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace OwnApt.Tests.Component.DataAnnotations
{
    public class MinElementsTests
    {
        #region Public Methods

        [Fact]
        public void CannotValidateWhenMinELementsIsNotSatisfied()
        {
            var validationResults = new List<ValidationResult>();
            var testObject = new TestObject(false);
            var isValid = Validator.TryValidateObject(testObject, new ValidationContext(testObject), validationResults, true);

            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void CanValidateWhenMinElementsIsSatisfied()
        {
            var validationResults = new List<ValidationResult>();
            var testObject = new TestObject(true);

            var isValid = Validator.TryValidateObject(testObject, new ValidationContext(testObject), validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        #endregion Public Methods
    }

    internal class TestObject
    {
        #region Public Constructors

        public TestObject(bool initialize)
        {
            this.StringList = new List<string>();
            this.IntList = new List<int>();
            this.StringCollection = new Collection<string>();
            this.IntCollection = new Collection<int>();
            this.StringArray = new string[3];
            this.IntArray = new int[3];
            this.Dictionary = new Dictionary<int, string>();

            if (initialize)
            {
                this.StringList = new List<string> { "Test", "Test", "Test" };
                this.IntList = new List<int> { 1, 2, 3 };
                this.StringCollection = new Collection<string> { "Test", "Test", "Test" };
                this.IntCollection = new Collection<int> { 1, 2, 3 };
                this.StringArray = new string[] { "Test", "Test", "Test" };
                this.IntArray = new int[] { 1, 2, 3 };
                this.Dictionary = new Dictionary<int, string>
                {
                    { 1, "Test" },
                    { 2, "Test" },
                    { 3, "Test" }
                };
            }
        }

        #endregion Public Constructors

        #region Public Properties

        [MinElements(3)]
        public Dictionary<int, string> Dictionary { get; set; }

        [MinElements(3)]
        public int[] IntArray { get; set; }

        [MinElements(3)]
        public Collection<int> IntCollection { get; set; }

        [MinElements(3)]
        public List<int> IntList { get; set; }

        [MinElements(3)]
        public string[] StringArray { get; set; }

        [MinElements(3)]
        public Collection<string> StringCollection { get; set; }

        [MinElements(3)]
        public List<string> StringList { get; set; }

        #endregion Public Properties
    }
}

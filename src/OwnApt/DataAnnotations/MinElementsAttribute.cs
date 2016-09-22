using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace OwnApt.Common.DataAnnotations
{
    public class MinElementsAttribute : ValidationAttribute
    {
        #region Private Fields

        private readonly int minElements;

        #endregion Private Fields

        #region Public Constructors

        public MinElementsAttribute(int minElements) : base($"Collection must have a size of at least {minElements}")
        {
            this.minElements = minElements;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ICollection collection;

            if (value is IDictionary)
            {
                var dictionary = value as IDictionary;
                collection = dictionary.Values as ICollection;
            }
            else
            {
                collection = value as ICollection;
            }

            if (collection == null || collection.Count < this.minElements)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        #endregion Protected Methods
    }
}

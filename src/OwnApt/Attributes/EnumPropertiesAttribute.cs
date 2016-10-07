using System;

namespace OwnApt.Common.Attributes
{
    public sealed class EnumPropertiesAttribute : Attribute
    {
        #region Public Constructors

        public EnumPropertiesAttribute(string name, string description)
        {
            this.ShortDescription = name;
            this.Description = description;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Description { get; }
        public string ShortDescription { get; }

        #endregion Public Properties
    }
}

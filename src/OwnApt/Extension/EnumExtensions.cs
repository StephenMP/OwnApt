using OwnApt.Common.Attributes;
using System;
using System.Reflection;

namespace OwnApt.Common.Extension
{
    public static class EnumExtensions
    {
        #region Public Methods

        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var fieldInfo = value.GetType().GetTypeInfo().GetField(value.ToString());
            var attributes = (TAttribute[])fieldInfo.GetCustomAttributes(typeof(TAttribute), false);
            return attributes == null || attributes.Length == 0 ? null : attributes[0];
        }

        public static string GetEnumPropertiesDescription(this Enum value)
        {
            var enumDescription = GetAttribute<EnumPropertiesAttribute>(value);
            return enumDescription == null ? value.ToString() : enumDescription.Description;
        }

        public static string GetEnumPropertiesShortDescription(this Enum value)
        {
            var enumDescription = GetAttribute<EnumPropertiesAttribute>(value);
            return enumDescription == null ? value.ToString() : enumDescription.ShortDescription;
        }

        #endregion Public Methods
    }
}

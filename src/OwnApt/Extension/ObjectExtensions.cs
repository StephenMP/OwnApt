using System;
using System.Collections;

namespace OwnApt.Common.Extension
{
    public static class ObjectExtensions
    {
        #region Public Methods

        public static int GetHashCodeSafe(this object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            if (obj is string)
            {
                var str = obj as string;
                return GetHashCodeSafe(str);
            }

            if (obj is DateTime)
            {
                var dt = (DateTime)obj;
                return GetHashCodeSafe(dt);
            }

            if (obj is IEnumerable)
            {
                var enumerable = obj as IEnumerable;
                return GetHashCodeSafe(enumerable);
            }

            return obj.GetHashCode();
        }

        public static int GetHashCodeSafe(this DateTime dt)
        {
            return dt.Date.Year.GetHashCodeSafe()
                ^ dt.Date.Month.GetHashCodeSafe()
                ^ dt.Date.Day.GetHashCodeSafe()
                ^ dt.Date.Hour.GetHashCodeSafe()
                ^ dt.Date.Minute.GetHashCodeSafe()
                ^ dt.Date.Second.GetHashCodeSafe()
                ^ dt.Date.Millisecond.GetHashCodeSafe();
        }

        public static int GetHashCodeSafe(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? 0 : str.GetHashCode();
        }

        public static int GetHashCodeSafe(this IEnumerable enumerable)
        {
            if (enumerable == null || !enumerable.GetEnumerator().MoveNext())
            {
                return 0;
            }

            var hash = 0;

            foreach (var element in enumerable)
            {
                hash ^= element.GetHashCodeSafe();
            }

            return hash;
        }

        #endregion Public Methods
    }
}

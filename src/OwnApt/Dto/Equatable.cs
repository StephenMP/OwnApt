using OwnApt.Common.Extension;
using System;
using System.Reflection;

namespace OwnApt.Common.Dto
{
    public abstract class Equatable
    {
        #region Public Methods

        public static bool operator ==(Equatable a, Equatable b)
        {
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.GetHashCode() == b.GetHashCode();
        }

        public static bool operator !=(Equatable a, Equatable b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return this == (Equatable)obj;
        }

        public override int GetHashCode()
        {
            var hash = 0;

            foreach(var property in this.GetType().GetProperties())
            {
                hash ^= property.GetValue(this).GetHashCodeSafe();
            }

            return hash;
        }

        #endregion Public Methods
    }
}

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
            return a.Equals(b);
        }

        public static bool operator !=(Equatable a, Equatable b)
        {
            return !(a == b);
        }


        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
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

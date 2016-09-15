using OwnApt.Common.Extension;
using System;
using System.Reflection;

namespace OwnApt.Common.Dto
{
    public abstract class Equatable
    {
        #region Public Methods

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if ((this == null) || (obj == null))
            {
                return false;
            }

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

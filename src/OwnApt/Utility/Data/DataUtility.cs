using System;

namespace OwnApt.Common.Utility.Data
{
    public static class DataUtility
    {
        #region Public Methods

        public static string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }

        #endregion Public Methods
    }
}

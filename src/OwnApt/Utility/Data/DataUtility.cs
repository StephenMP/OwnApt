using OwnApt.Common.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnApt.Common.Utility.Data
{
    public static class DataUtility
    {
        public static string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}

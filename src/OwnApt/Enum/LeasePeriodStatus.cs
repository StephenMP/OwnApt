using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnApt.Common.Enum
{
    public enum LeasePeriodStatus
    {
        Unknown = 0,
        PaymentDue = 1,
        PaymentReceived = 2,
        Closed = 3
    }
}

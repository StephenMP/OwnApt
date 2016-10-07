using OwnApt.Common.Attributes;

namespace OwnApt.Common.Enums
{
    public enum LeasePeriodStatus
    {
        Unknown = 0,

        [EnumProperties("Payment Due", "Rent Payment is Due")]
        PaymentDue = 1,

        [EnumProperties("Payment Received/Processing", "Rent Payment Has Been Received and is Processing")]
        PaymentReceived = 2,

        [EnumProperties("Closed", "Rent Payment Has Been Distributed")]
        Closed = 3
    }
}

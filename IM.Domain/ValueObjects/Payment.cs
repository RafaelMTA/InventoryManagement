using IM.Domain.Enum;

namespace IM.Domain.ValueObjects
{
    public class Payment
    {
        public DateTime Payday { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}

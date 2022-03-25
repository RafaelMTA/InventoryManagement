using IM.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace IM.Domain.ValueObjects
{
    [Owned]
    public class Payment
    {
        public DateTime Payday { get; set; }
        public PaymentMethod PaymentMethod { get; set; }      
        public PaymentStatus PaymentStatus { get; set; }
    }
}

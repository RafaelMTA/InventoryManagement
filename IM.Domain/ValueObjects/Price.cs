using IM.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace IM.Domain.ValueObjects
{
    [Owned]
    public class Price
    {
        public CurrencyType CurrencyType { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Value { get; set; }
        public decimal? Total { get { return Value * ExchangeRate; } }
    }
}

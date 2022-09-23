using IM.Domain.Enum;

namespace IM.Domain.ValueObjects
{
    public class Price
    {
        public CurrencyType CurrencyType { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Value { get; set; }
        public decimal? Total { get { return Value * ExchangeRate; } }
    }
}

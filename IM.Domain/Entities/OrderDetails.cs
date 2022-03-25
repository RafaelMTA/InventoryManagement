using IM.Domain.Enum;
using IM.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IM.Domain.Entities
{
    [Owned]
    public class OrderDetails
    {
        public DateTime Deadline { get; set; }
        public Address ShippingAddress { get; set; }
        public Payment Payment { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public OrderStatus Status { get; set; }    
    }
}

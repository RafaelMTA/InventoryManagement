﻿using IM.Domain.Interfaces.Entity;

namespace IM.Domain.Entities
{
    public class Order : AuditableEntity, IBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public OrderDetails Details { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public decimal Total { get { return OrderItems.Sum(x => x.Product?.Price.Total ?? 0); } }
    }
}

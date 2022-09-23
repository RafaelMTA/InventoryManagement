namespace IM.Domain.Entities
{
    public class OrderItem : AuditableEntity
    {
        public virtual Product Product { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}

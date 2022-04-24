using IM.Domain.Interfaces.Entity;
using IM.Domain.ValueObjects;

namespace IM.Domain.Entities
{
    public class Product : AuditableEntity, IBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }       
        public Price Price { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public bool ValidatePricing()
        {
            if (ProductInventories == null || ProductInventories.Count <= 0) return true;
            decimal priceOfAllInvs = this.ProductInventories.Sum(x => x.Inventory?.Price.Total ?? 0);
            if (priceOfAllInvs < Price.Total) return false;

            return true;
        }
    }
}

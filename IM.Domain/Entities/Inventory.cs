using IM.Domain.Interfaces.Entity;
using IM.Domain.ValueObjects;

namespace IM.Domain.Entities
{
    public class Inventory : AuditableEntity, IBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Price Price { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
    }
}

using IM.Domain.Interfaces.Entity;

namespace IM.Domain.Entities
{
    public class ProductInventory : AuditableEntity, IBaseEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        public int Quantity { get; set; }
    }
}

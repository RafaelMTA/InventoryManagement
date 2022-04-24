using IM.Domain.Interfaces.Entity;

namespace IM.Domain.Entities
{
    public class ProductInventory : AuditableEntity, IBaseEntity
    {
        public virtual Product Product { get; set; }
        public virtual Inventory Inventory { get; set; }
        public int Quantity { get; set; }
    }
}

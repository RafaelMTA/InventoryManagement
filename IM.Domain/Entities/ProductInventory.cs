namespace IM.Domain.Entities
{
    public class ProductInventory : AuditableEntity
    {
        public virtual Product Product { get; set; }
        public virtual Inventory Inventory { get; set; }
        public int Quantity { get; set; }
    }
}

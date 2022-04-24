namespace IM.Domain.Entities
{
    public class ProductOrder : AuditableEntity
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

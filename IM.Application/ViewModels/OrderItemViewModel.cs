using IM.Domain.Entities;
using IM.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace IM.Application.ViewModels
{
    public class OrderItemViewModel
    {
        public virtual ProductViewModel Product { get; set; }
        public virtual ICollection<InventoryViewModel> Inventories { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        public virtual ICollection<OrderViewModel> Orders { get; set; }

    }
}

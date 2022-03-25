using IM.Domain.Interfaces.ViewModel;
using IM.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace IM.Application.ViewModels
{
    public class InventoryViewModel : IBaseEntityViewModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50, ErrorMessage = "Name must have a maximum of 50 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Name must have a maximum of 255 characters")]
        public string Description { get; set; }

        [Required]
        [Range(0,999)]
        public int Quantity { get; set; }

        [Required]
        public Price Price { get; set; }

        public Guid SupplierId { get; set; }

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

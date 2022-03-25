using IM.Domain.Interfaces.ViewModel;
using IM.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace IM.Application.ViewModels
{
    public class ProductViewModel : IBaseEntityViewModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MinLength(3)]
        [MaxLength(100, ErrorMessage = "Name must have a maximum of 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(200, ErrorMessage = "Name must have a maximum of 200 characters")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0,int.MaxValue, ErrorMessage = "Quantity must be greater or equal to {0}")]
        public int Quantity { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public Price Price { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

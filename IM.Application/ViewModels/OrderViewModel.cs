using IM.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace IM.Application.ViewModels
{
    public class OrderViewModel : AuditableEntityViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name must have a maximum of 50 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Name must have a maximum of 255 characters")]
        public string Description { get; set; }

        public Address ShippingAddress { get; set; }

        public Payment Payment { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Total { get { return OrderItems!.Sum(x => x.Product?.Price.Total ?? 0); } }
    }
}

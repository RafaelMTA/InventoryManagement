using IM.Domain.Enum;
using IM.Domain.Interfaces.ViewModel;
using IM.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace IM.Application.ViewModels
{
    public class SupplierViewModel : IBaseEntityViewModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100, ErrorMessage = "Name must have a maximum of 100 characters")]
        public string TradeName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name must have a maximum of 100 characters")]
        public string LegalName { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public CompanySegment CompanySegment { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

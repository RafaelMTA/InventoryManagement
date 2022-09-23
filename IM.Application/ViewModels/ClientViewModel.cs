using IM.Domain.Enum;
using IM.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace IM.Application.ViewModels
{
    public class ClientViewModel : AuditableEntityViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name must have a maximum of 100 characters")]
        public string TradeName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name must have a maximum of 100 characters")]
        public string LegalName { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public CompanySegment CompanySegment { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace IM.Application.ViewModels
{
    public abstract class AuditableEntityViewModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
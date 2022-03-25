using IM.Domain.Interfaces.Entity;

namespace IM.Domain.Entities
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual UserDetails UserDetails { get; set; }
    }
}

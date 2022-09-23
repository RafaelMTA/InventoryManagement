namespace IM.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual UserDetails UserDetails { get; set; }
    }
}

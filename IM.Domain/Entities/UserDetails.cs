using IM.Domain.Interfaces.Entity;

namespace IM.Domain.Entities
{
    public class UserDetails : IBaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}

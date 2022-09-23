namespace IM.Domain.Entities
{
    public class UserDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}

namespace IM.Application.ViewModels
{
    public class UserViewModel : AuditableEntityViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? UserDetailsId { get; set; }
        public UserDetailViewModel UserDetails { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

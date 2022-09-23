namespace IM.Application.ViewModels
{
    public class UserDetailViewModel : AuditableEntityViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}
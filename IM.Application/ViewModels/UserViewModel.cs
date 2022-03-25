using IM.Domain.Entities;
using IM.Domain.Interfaces.ViewModel;

namespace IM.Application.ViewModels
{
    public class UserViewModel : IBaseEntityViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? UserDetailsId { get; set; }
        public UserDetails UserDetails { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

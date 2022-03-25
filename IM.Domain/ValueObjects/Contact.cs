using Microsoft.EntityFrameworkCore;

namespace IM.Domain.ValueObjects
{
    [Owned]
    public class Contact
    {
        public string Phone { get; set; }
        public Email Email { get; set; }
    }
}

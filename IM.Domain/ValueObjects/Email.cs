using Microsoft.EntityFrameworkCore;

namespace IM.Domain.ValueObjects 
{
    [Owned]
    public class Email
    {
        public string Value { get; set; }

        public Email() { }

        public Email(string value)
        {
            if(!value.Contains("@")) throw new Exception("Email is invalid");

            Value = value;
        }
    }
}

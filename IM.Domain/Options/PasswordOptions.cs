namespace IM.Domain.Options
{
    public class PasswordOptions
    {
        public int SaltSize { get; set; }
        public int HashSize { get; set; }
        public int Iterations { get; set; }
    }
}

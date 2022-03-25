namespace IM.Application.Interfaces.Services
{
    public interface IPasswordHash
    {
        string Hash(string password);
        bool Verify(string password, string hashedPassword);
    }
}

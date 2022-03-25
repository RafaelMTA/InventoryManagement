using IM.Application.Model;

namespace IM.Application.Interfaces.Services
{
    public interface IJwtToken
    {
        public string Generate(IEnumerable<CustomClaimModel> claims);
    }
}

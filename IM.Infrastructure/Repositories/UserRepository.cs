using IM.Application.Interfaces.Repositories;
using IM.Application.Interfaces.Services;
using IM.Application.Model;
using IM.Domain.Entities;
using IM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace IM.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtToken _token;
        private readonly IPasswordHash _hash;

        public UserRepository(ApplicationDbContext context, IJwtToken token, IPasswordHash hash) : base(context)
        {
            _context = context;
            _token = token;
            _hash = hash;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
            if (user == null) throw new Exception(); //User not Registered

            bool passwordMatch = _hash.Verify(password, user.Password);
            if (!passwordMatch) throw new Exception(); //Invalid Credentials
            
            return _token.Generate(GetClaims(user));
        }

        public override async Task Insert(User user)
        {
            var result = await _context.Users.FirstOrDefaultAsync(a => a.Email == user.Email);
            if (result != null) throw new Exception(); //User already registered

            _context.Users.Add(user);
        }

        public override async Task<User> GetById(Guid id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(e => e.UserDetails)
                .SingleAsync(x => x.Id == id);
            if (user == null) throw new Exception(); //User not Registered

            return user;
        }

        private IEnumerable<CustomClaimModel> GetClaims(User user)
        {
            var claims = new List<CustomClaimModel>();

            claims.Add(new CustomClaimModel("email", user.Email));
            claims.Add(new CustomClaimModel("id", user.Id.ToString()));

            return claims;
        }
    }
}

using AuthenticationAPI.Interfaces;
using AuthenticationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Services
{
    public class UserRepo : IRepo
    {
        private readonly CustomerContext _context;

        public UserRepo(CustomerContext context)
        {
            _context = context;
        }
        public async Task<USer> Add(USer user)
        {
            _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<USer> Get(USer user)
        {
            var myUser = await _context.Users.SingleOrDefaultAsync(u=>u.Username == user.Username);
            return myUser;
        }
    }
}

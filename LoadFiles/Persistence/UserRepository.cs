using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoadFiles.Core;
using LoadFiles.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadFiles.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly LoadFilesDbContext _context;

        public UserRepository(LoadFilesDbContext context)
        {
            this._context = context;
        }
        public async Task<User> Get(int userId)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.OrderBy(u => u.Name).ToArrayAsync();
        }
    }
}
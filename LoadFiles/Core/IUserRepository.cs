using System.Collections.Generic;
using System.Threading.Tasks;
using LoadFiles.Core.Models;

namespace LoadFiles.Core
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(int userId);
    }
}
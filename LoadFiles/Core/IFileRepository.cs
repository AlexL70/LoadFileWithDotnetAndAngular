using System.Collections.Generic;
using System.Threading.Tasks;
using LoadFiles.Core.Models;

namespace LoadFiles.Core
{
    public interface IFileRepository
    {
        Task<IEnumerable<File>> GetAll();
        Task Add(File file);
    }
}
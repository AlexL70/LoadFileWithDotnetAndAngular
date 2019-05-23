using System.Collections.Generic;
using System.Threading.Tasks;
using LoadFiles.Core;
using LoadFiles.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadFiles.Persistence {
    public class FileRepository : IFileRepository {
        private readonly LoadFilesDbContext _context;
        public FileRepository (LoadFilesDbContext context) {
            this._context = context;
        }

        public async Task Add (File file) {
            await _context.AddAsync(file);
        }

        public async Task<IEnumerable<File>> GetAll () {
            return await _context.Files.Include(f => f.User)
                .ToArrayAsync();
        }
    }
}
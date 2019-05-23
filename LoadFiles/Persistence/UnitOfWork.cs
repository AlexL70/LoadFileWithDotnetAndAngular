using System.Threading.Tasks;
using LoadFiles.Core;

namespace LoadFiles.Persistence {
    public class UnitOfWork : IUnitOfWork {
        private readonly LoadFilesDbContext _context;
        public UnitOfWork (LoadFilesDbContext context) {
            this._context = context;
        }
        public async Task Complete () {
            await _context.SaveChangesAsync();
        }
    }
}
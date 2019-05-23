using Microsoft.EntityFrameworkCore;

namespace LoadFiles.Persistence
{
    public class LoadFilesDbContext : DbContext
    {
        public LoadFilesDbContext(DbContextOptions<LoadFilesDbContext> options)
            : base(options) {}
    }
}
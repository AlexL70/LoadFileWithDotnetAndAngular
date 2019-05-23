using LoadFiles.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadFiles.Persistence
{
    public class LoadFilesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }

        public LoadFilesDbContext(DbContextOptions<LoadFilesDbContext> options)
            : base(options) {}
    }
}
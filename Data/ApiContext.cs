using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApiContext(DbContextOptions options)
            : base(options) { }
            
    }
}
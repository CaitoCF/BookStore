using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<BookModel> Book { get; set; }
        public DbSet<AuthorModel> Author { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<MovementModel> Movement { get; set; }
    }
}

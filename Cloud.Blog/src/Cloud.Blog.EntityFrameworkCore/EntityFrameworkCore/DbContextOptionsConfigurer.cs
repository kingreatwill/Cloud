using Microsoft.EntityFrameworkCore;

namespace Cloud.Blog.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<BlogDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for BlogDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}

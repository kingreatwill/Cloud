using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Cloud.Blog.Categories;
using Cloud.Blog.Domain.Repositories;
using Cloud.Blog.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cloud.Blog.EntityFrameworkCore
{
    [AutoRepositoryTypes(
       typeof(IBlogRepository<>),
       typeof(IBlogRepository<,>),
       typeof(BlogRepositoryBase<>),
       typeof(BlogRepositoryBase<,>),
       WithDefaultRepositoryInterfaces = true
       )]
    public class BlogDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public virtual DbSet<Category> Categories { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }
    }
}
using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Cloud.Blog.EntityFrameworkCore;
using Cloud.Blog.Tests.TestDatas;

namespace Cloud.Blog.Tests
{
    public class BlogTestBase : AbpIntegratedTestBase<BlogTestModule>
    {
        public BlogTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<BlogDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<BlogDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<BlogDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<BlogDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<BlogDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<BlogDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<BlogDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<BlogDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}

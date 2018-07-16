using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Cloud.Blog.Web.Startup;
namespace Cloud.Blog.Web.Tests
{
    [DependsOn(
        typeof(BlogWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class BlogWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogWebTestModule).GetAssembly());
        }
    }
}
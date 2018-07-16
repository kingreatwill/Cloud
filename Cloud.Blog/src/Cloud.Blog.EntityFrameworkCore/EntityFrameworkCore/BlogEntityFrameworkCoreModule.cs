using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Cloud.Blog.EntityFrameworkCore
{
    [DependsOn(
        typeof(BlogCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class BlogEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogEntityFrameworkCoreModule).GetAssembly());
        }
    }
}
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Cloud.Blog
{
    [DependsOn(
        typeof(BlogCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BlogApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogApplicationModule).GetAssembly());
        }
    }
}
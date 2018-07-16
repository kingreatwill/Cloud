using Abp.Modules;
using Abp.Reflection.Extensions;
using Cloud.Blog.Localization;

namespace Cloud.Blog
{
    public class BlogCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            BlogLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogCoreModule).GetAssembly());
        }
    }
}
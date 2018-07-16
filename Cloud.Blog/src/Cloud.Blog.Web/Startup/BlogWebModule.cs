using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Cloud.Blog.Configuration;
using Cloud.Blog.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Cloud.Blog.Web.Startup
{
    [DependsOn(
        typeof(BlogApplicationModule),
        typeof(BlogEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreModule))]
    public class BlogWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public BlogWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(BlogConsts.ConnectionStringName);

            //Configuration.Modules.AbpWebCommon().AntiForgery. = false;
            //Configuration.Modules.AbpWebCommon().AntiForgery.TokenCookieName
            Configuration.Navigation.Providers.Add<BlogNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(BlogApplicationModule).GetAssembly()
                );
            //Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(MyApplicationModule).Assembly, moduleName: 'app', useConventionalHttpVerbs: true);
            //api/services/<module-name>/<service-name>/<method-name>
            /*
                Get: Used if the method name starts with 'Get'.
                Put: Used if the method name starts with 'Put' or 'Update'.
                Delete: Used if the method name starts with 'Delete' or 'Remove'.
                Post: Used if the method name starts with 'Post', 'Create' or 'Insert'.
                Patch: Used if the method name starts with 'Patch'.
                Otherwise, Post is used by default as an HTTP verb.

            <script src="~/AbpServiceProxies/GetAll?type=jquery" type="text/javascript"></script>
             */
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogWebModule).GetAssembly());
        }
    }
}
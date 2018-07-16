using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Cloud.Blog.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Cloud.Blog.Web.Startup
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Configure DbContext
            services.AddAbpDbContext<BlogDbContext>(options =>
            {
                DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            });
            /*

             [AutoValidateAntiforgeryToken] – This adds the Antiforgery validation on any “unsafe” requests, where unsafe means requests with a method other than GET, HEAD, TRACE and OPTIONS. (As the other HTTP methods are meant for requests that change the server state). It will be applied globally (when added as a global filter) or at class level (when added to a specific controller class).
[ValidateAntiForgeryToken] – This is used to add the Antiforgery validation to a specific controller action or class. It does not take into account the request HTTP method. So if added to a class, it will add the validation to all actions, even those with methods GET, HEAD, TRACE or OPTIONS.
[IgnoreAntiforgeryToken] – Disables the Antiforgery validation in a specific action or controller. For example, you might add the Antiforgery validation globally or to an entire controller class, but you might still want to ignore the validation in specific actions.
             */
            services.AddMvc(options =>
            {
                options.Filters.Add(new IgnoreAntiforgeryTokenAttribute());
            });
            //Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "AbpZeroTemplate API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });

            //Configure Abp and Dependency Injection
            return services.AddAbp<BlogWebModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); //Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //URL: /swagger
            app.UseSwagger();
            //Enable middleware to serve swagger - ui assets(HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AbpZeroTemplate API V1");
            });
        }
    }
}
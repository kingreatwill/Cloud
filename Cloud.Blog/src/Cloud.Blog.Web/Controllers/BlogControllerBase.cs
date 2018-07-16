using Abp.AspNetCore.Mvc.Controllers;

namespace Cloud.Blog.Web.Controllers
{
    public abstract class BlogControllerBase: AbpController
    {
        protected BlogControllerBase()
        {
            LocalizationSourceName = BlogConsts.LocalizationSourceName;
        }
    }
}
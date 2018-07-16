using Abp.AspNetCore.Mvc.Views;

namespace Cloud.Blog.Web.Views
{
    public abstract class BlogRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected BlogRazorPage()
        {
            LocalizationSourceName = BlogConsts.LocalizationSourceName;
        }
    }
}

using Abp.Application.Services;

namespace Cloud.Blog
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class BlogAppServiceBase : ApplicationService
    {
        protected BlogAppServiceBase()
        {
            LocalizationSourceName = BlogConsts.LocalizationSourceName;
        }
    }
}
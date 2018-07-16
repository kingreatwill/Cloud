using System.Threading.Tasks;
using Cloud.Blog.Web.Controllers;
using Shouldly;
using Xunit;

namespace Cloud.Blog.Web.Tests.Controllers
{
    public class HomeController_Tests: BlogWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}

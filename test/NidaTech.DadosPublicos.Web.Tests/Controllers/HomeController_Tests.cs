using System.Threading.Tasks;
using NidaTech.DadosPublicos.Models.TokenAuth;
using NidaTech.DadosPublicos.Web.Controllers;
using Shouldly;
using Xunit;

namespace NidaTech.DadosPublicos.Web.Tests.Controllers
{
    public class HomeController_Tests: DadosPublicosWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
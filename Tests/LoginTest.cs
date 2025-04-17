using NUnit.Framework;
using SeleniumOOPTest.Base;
using SeleniumOOPTest.Pages;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;
using NUnit.Allure.Core;

namespace SeleniumOOPTest.Tests
{
    [AllureNUnit]
    [AllureSuite("Login")]
    [AllureSubSuite("Positive")]
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private HomePage homePage;

        [SetUp]
        public void SetUpTest()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
        }

        [Test]
        [AllureOwner("husnuye")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("login", "smoke")]
        [AllureDescription("Valid login scenario for saucedemo.com")]
        public void SuccessfulLoginTest()
        {
            AllureApi.Step("Login with valid credentials", () =>
            {
                loginPage.Login("standard_user", "secret_sauce");
            });

            AllureApi.Step("Verify inventory page is visible", () =>
            {
                Assert.IsTrue(homePage.IsInventoryDisplayed(), "Login failed or inventory not visible.");
            });
        }
    }
}
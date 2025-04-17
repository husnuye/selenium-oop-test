using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumOOPTest.Base;
using SeleniumOOPTest.Pages; // ✅ LogoutPage ve LoginPage buradan geliyor

namespace SeleniumOOPTest.Tests
{
    public class LogoutTest : BaseTest
    {
        private LoginPage loginPage;
        private LogoutPage logoutPage;

        [SetUp]
        public void SetUpTest()
        {
            loginPage = new LoginPage(driver);
            logoutPage = new LogoutPage(driver);
        }

        [Test]
        public void UserShouldBeAbleToLogout()
        {
            // Giriş yap
            loginPage.Login("standard_user", "secret_sauce");

            // Çıkış yap
            logoutPage.Logout();

            // URL kontrolü: Login sayfasına yönlendirme başarılı mı?
            Assert.IsTrue(driver.Url.Contains("saucedemo.com"), "Logout yönlendirmesi başarısız.");
        }
    }
}
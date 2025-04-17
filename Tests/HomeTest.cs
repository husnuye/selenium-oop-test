using NUnit.Framework;
using SeleniumOOPTest.Base;
using SeleniumOOPTest.Pages;
using OpenQA.Selenium;

namespace SeleniumOOPTest.Tests
{
    public class HomeTest : BaseTest
    {
        private LoginPage loginPage;
        private HomePage homePage;
        private LogoutPage logoutPage;

        [SetUp]
        public void SetUpTest()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            logoutPage = new LogoutPage(driver);
        }

        [Test]
        public void HomePage_ShouldDisplayInventory_WhenUserIsLoggedIn()
        {
            loginPage.Login("standard_user", "secret_sauce");
            Assert.IsTrue(homePage.IsInventoryDisplayed(), "Inventory list is not displayed.");
        }


        [Test]
        public void UserShouldBeAbleToLogout()
        {
            loginPage.Login("standard_user", "secret_sauce");

            // Menü butonuna tıkla (sağ üst hamburger menü)
            logoutPage.Click(By.Id("react-burger-menu-btn"));

            // Logout linki görünene kadar bekle ve ekran kaydır
            logoutPage.ScrollToElement(By.Id("logout_sidebar_link"));
            logoutPage.Click(By.Id("logout_sidebar_link"));

            // Doğrulama
            Assert.IsTrue(driver.Url.Contains("saucedemo.com"), "User is not redirected to login page after logout.");
        }






    }
}
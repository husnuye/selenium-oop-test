using NUnit.Framework;
using SeleniumOOPTest.Base;
using SeleniumOOPTest.Pages;
using OpenQA.Selenium;

namespace SeleniumOOPTest.Tests
{
    public class CheckoutTest : BaseTest
    {
        private LoginPage loginPage;
        private HomePage homePage;
        private CheckoutPage checkoutPage;

        [SetUp]
        public void SetUpTest()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            checkoutPage = new CheckoutPage(driver);
        }

        [Test]
        public void UserCanCompleteCheckoutProcess()
        {
            // Login
            loginPage.Login("standard_user", "secret_sauce");

            // Sepete ürün ekle
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            // Pop-up varsa kapat
            checkoutPage.ClosePopupIfExists();

            // Checkout başlat
            driver.FindElement(By.Id("checkout")).Click();

            // Formu doldur
            checkoutPage.FillCheckoutInformation("John", "Doe", "12345");
            checkoutPage.ClickContinue();
            checkoutPage.ClickFinish();

            // Başarı mesajını doğrula
            Assert.IsTrue(checkoutPage.IsCheckoutComplete(), "Checkout was not completed successfully.");
        }
    }
}
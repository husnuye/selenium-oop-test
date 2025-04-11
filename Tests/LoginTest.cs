using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumOOPTest.Pages;
using SeleniumOOPTest.Utils;

namespace SeleniumOOPTest.Tests
{
    public class LoginTest
    {
        /// <summary>
        /// Represents the WebDriver instance used to interact with the browser during tests.
        /// </summary>
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
        }


        [Test]
        public void SuccessfulLoginTest()
        {
            var loginPage = new LoginPage(driver);

            loginPage.Login("student", "Password123");
            Assert.That(driver.Url, Does.Contain("logged-in-successfully")); // Yeni versiyonda böyle
        }

        [TearDown]
        public void TearDown()
        {
            if (driver == null)
            {
                return;
            }
            driver.Quit();
            driver.Dispose(); // Quit'e ek olarak Dispose da yaz
        }


    }
}

    


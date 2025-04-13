using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumOOPTest.Pages;
using SeleniumOOPTest.Utils;
using AllureAttributes = Allure.NUnit.Attributes; // 🎯 Alias burada tanımlı
using Allure.Net.Commons;

namespace SeleniumOOPTest.Tests
{
    [TestFixture]
    [AllureAttributes.AllureSuite("Login Suite")]
    public class LoginTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
        }

        [Test]
        [AllureAttributes.AllureOwner("husnuye")]
        [AllureAttributes.AllureTag("login", "smoke")]
        [AllureAttributes.AllureSeverity(SeverityLevel.normal)]
        //
        [AllureAttributes.AllureSubSuite("basic")]
        public void SuccessfulLoginTest()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("student", "Password123");

            Assert.That(driver.Url, Does.Contain("logged-in-successfully"));
        }

        [TearDown]
        public void TearDown()
        {
            if (driver == null) return;

            driver.Quit();
            driver.Dispose();
        }
    }
}

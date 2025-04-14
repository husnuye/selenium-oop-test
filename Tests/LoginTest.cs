using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumOOPTest.Pages;
using SeleniumOOPTest.Utils;
using Allure.NUnit.Attributes; // 🎯 Alias burada tanımlı
using Allure.Net.Commons;
using Allure.NUnit;
using NUnit.Allure.Core;

namespace SeleniumOOPTest.Tests
{

    [Allure.NUnit.AllureNUnit]
    [AllureSuite("Login Tests")]
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
        [AllureOwner("husnuye")]
        [AllureTag("login", "smoke")]
        [AllureSeverity(SeverityLevel.normal)]
        //
        [AllureSubSuite("basic")]
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

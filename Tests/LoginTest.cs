using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumOOPTest.Pages;
using SeleniumOOPTest.Utils;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;
using NUnit.Allure.Core;

namespace SeleniumOOPTest.Tests
{
    [Allure.NUnit.AllureNUnit]
    [AllureSuite("Login")]
    [AllureSubSuite("Positive")]
    public class LoginTest
    {
        private IWebDriver driver;
        private bool disposed = false;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
        }

        [Test]
        [AllureOwner("husnuye")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("login", "smoke")]
        [AllureDescription("Valid login scenario using correct username and password.")]
        public void SuccessfulLoginTest()
        {
            AllureApi.Step("Navigate to Login Page", () =>
            {
                driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            });

            AllureApi.Step("Fill login form and submit", () =>
            {
                var loginPage = new LoginPage(driver);
                loginPage.Login("student", "Password123");
            });

            AllureApi.Step("Verify user is redirected to success page", () =>
            {
                var currentUrl = driver.Url;
                Assert.That(currentUrl, Does.Contain("logged-in-successfully"),
                    $"Expected to be on success page, but was on {currentUrl}");
            });
        }
        [TearDown]
        public void TearDown()
        {
            Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        }
    }

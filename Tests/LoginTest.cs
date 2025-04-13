using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumOOPTest.Pages;
using SeleniumOOPTest.Utils;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons; 

namespace SeleniumOOPTest.Tests
{   

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Login Suite")]
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
        [AllureTag("smoke")] // ✅ Allure etiketi (raporda gruplanabilir)
        //
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)] // ✅ Hata ciddiyeti (low, normal, critical vs.)
        [AllureOwner("husnuye")] // ✅ Kimin yazdığı
        [AllureSuite("Login")] // ✅ Testin ait olduğu suite
        [AllureSubSuite("Basic")] // ✅ 
        
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
            // This is a test change to trigger GitHub Actions

        }


    }
}

    


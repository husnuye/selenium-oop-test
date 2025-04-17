using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumOOPTest.Utils;
using System;
using System.IO;
using Allure.Commons;

namespace SeleniumOOPTest.Base
{
    [NonParallelizable] //  Burası kritik parel testi engellenir
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            driver.Navigate().GoToUrl(ConfigReader.GetSetting("BaseUrl"));
        }

        [TearDown]
        public void TearDown()
        {
            if (driver == null)
                return;

            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                try
                {
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    var screenshotPath = $"Screenshots/{Guid.NewGuid()}.png";
                    Directory.CreateDirectory("Screenshots"); // klasör yoksa oluştur
                    File.WriteAllBytes(screenshotPath, screenshot.AsByteArray);
                    AllureLifecycle.Instance.AddAttachment("Screenshot", "image/png", screenshotPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Screenshot capture failed: {ex.Message}");
                }
            }
//  Driver'ı her durumda güvenli şekilde kapat
            
            try
            {
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Driver quit failed: {ex.Message}");
            }

        
            
        }
    }
}